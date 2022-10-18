using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Core.DTOs.Constants;
using Core.DTOs.Transactions;
using Core.DTOs.Transactions.Json;
using Core.Entities.TransactionEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        HttpClient _client = new HttpClient();

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<List<TransactionsSuccessResponseDTO>> RegisterTransactionsPrivat(string userId, DateTime @from, DateTime to)
        {
            var user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(predicate: u => u.Id == userId, include: source => source.Include(u => u.Banks).ThenInclude(b => b.Cards).ThenInclude(c => c.Transactions), disableTracking: false);
            if (user == null)
            {
                throw new HttpException($"User with id : {userId} not found!", System.Net.HttpStatusCode.BadRequest);
            }

            var result = new List<TransactionsSuccessResponseDTO>();
            var bank = user.Banks.FirstOrDefault(b => b.BankId == (int)Bank.PRIVATBANK);
            if (bank == null)
            {
                throw new HttpException("User bank (PrivatBank) doesn`t exist", System.Net.HttpStatusCode.BadRequest);
            }
            //var privatBank =
            //    user.Banks.FirstOrDefault(el => el.BankId == (int)Bank.PRIVATBANK); // If exist privatbank
            //if (privatBank == null)
            //{
            //    throw new HttpException("PrivatBank card doesn`t exists",
            //        System.Net.HttpStatusCode.BadRequest);
            //    //var userBank = new Entities.UserEntity.UserBank
            //    //{
            //    //    BankId = 2,
            //    //    UserId = userId,
            //    //    BankToken = password
            //    //};
            //    ////var card = new Entities.CardEntity.Card
            //    ////    {CardNumber = cardNumber, MerchantId = merchantId, MerchantPassword = password, Transactions = responseModel.Response.Data.Info.Statements.Statement};
            //    ////userBank.Cards.Add(card);  
            //    //await _unitOfWork.UserBankRepository.Insert(userBank);
            //}
           // _mapper.AssertConfigurationIsValid();
            foreach (var card in bank.Cards)
            {
                try
                {
                    if (!String.IsNullOrEmpty(card.MerchantId) && !String.IsNullOrEmpty(card.MerchantPassword) &&
                        !String.IsNullOrEmpty(card.CardNumber))
                    {
                        var signature =
                            $"<oper>cmt</oper><wait>0</wait><test>0</test><payment id=\"\"><prop name=\"sd\" value=\"{from.ToString("dd.MM.yyyy")}\"/><prop name=\"ed\" value=\"{to.ToString("dd.MM.yyyy")}\"/><prop name=\"card\" value=\"{card.CardNumber}\"/></payment>";

                        var hashedSignature = HashingHelper.CreateMd5(signature + card.MerchantPassword);
                        hashedSignature = HashingHelper.CreateSha1(hashedSignature);
                        var requestText =
                            $"<?xml version=\"1.0\" encoding=\"UTF-8\"?><request version=\"1.0\"><merchant><id>{card.MerchantId}</id><signature>{hashedSignature}</signature></merchant><data>{signature}</data></request>";
                        string responseText;
                        using (var message = new HttpRequestMessage(HttpMethod.Post,
                                   "https://api.privatbank.ua/p24api/rest_fiz"))
                        {
                            message.Content = new StringContent(requestText);
                            var response = await _client.SendAsync(message);
                            responseText = await response.Content.ReadAsStringAsync();
                            //JsonConvert.
                            //return JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), new { accounts = new List<AccountMonobankDTO>() }).accounts;
                        }

                        GlobalResponse responseModel; //= new Response(){ Merchant = "22"};
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseText);
                        //string 
                        var json = JsonConvert.SerializeXmlNode(doc);
                        responseModel = JsonConvert.DeserializeObject<GlobalResponse>(json);
                        foreach (var transaction in responseModel.Response.Data.Info.Statements.Statement)
                        {
                            float amount = float.Parse(transaction.Amount.Substring(0, transaction.Amount.Length - 4));
                            if (amount < 0  && card.Transactions.All(tr => tr.TransactionFromBankId != transaction.AppCode))
                            {
                                var transactionResult = new Transaction
                                    {Card = card, Description = transaction.Description, TransactionFromBankId = transaction.AppCode}; //, CreatedDate = transaction.
                                transactionResult.Currency = await _unitOfWork.CurrencyRepository.GetFirstOrDefaultAsync(predicate: c => c.ShortName == transaction.Amount.Substring(transaction.Amount.Length - 3, 3), disableTracking: false);
                                transactionResult.Card = card;
                                transactionResult.CreatedDate = transaction.TranDate;
                                transactionResult.Sum = amount;
                                await _unitOfWork.TransactionRepository.Insert(transactionResult);
                                await _unitOfWork.SaveChangesAsync();
                            }
                            
                            //await _unitOfWork.TransactionRepository.
                        }

                        result.Add(new TransactionsSuccessResponseDTO {Card = card.CardNumber, Status = "Success"});
                    }


                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    result.Add(new TransactionsSuccessResponseDTO {Card = card.CardNumber, Status = "Error"});
                }
            }
            return result;
            //var 
            //XmlSerializer ser = new XmlSerializer(typeof(Response));
            //ser.Deserialize(responseText)
            //ser.Serialize(responseModel);
            //using (TextReader reader = new StringReader(responseText))
            //{
            //    responseModel = (Response)ser.Deserialize(reader);
            //}

        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactionsBySubscription(Guid id)
        {
            var subscription = await _unitOfWork.SubscriptionRepository.GetById(id);
            return _mapper.Map<IEnumerable<TransactionDTO>>(subscription.Transactions);
            //throw new NotImplementedException();
        }

        public async Task<TransactionDTO> GetTransactionById(string transactionId)
        {
            return _mapper.Map<TransactionDTO>(await _unitOfWork.TransactionRepository.GetById(transactionId));
        }

        public async Task<bool> AddTransactionsFromExcel(string path)
        {
            using (var package = new ExcelPackage(path))
            {
                ExcelWorksheet mainSheet = package.Workbook.Worksheets[0];
                if (mainSheet == null)
                {
                    throw new HttpException("Excel worksheet is empty", System.Net.HttpStatusCode.BadRequest);
                }
                for (int i = 2; i <= mainSheet.Dimension.Rows; i++)
                {

                    if (mainSheet.Cells[i, 1].Value != null && mainSheet.Cells[i, 2].Value != null && mainSheet.Cells[i, 3].Value != null && mainSheet.Cells[i, 4].Value != null && mainSheet.Cells[i, 5].Value != null && mainSheet.Cells[i, 6].Value != null)
                    {
                        Transaction transaction = (await _unitOfWork.TransactionRepository.GetFirstOrDefaultAsync(el =>
                                el.TransactionFromBankId != null &&
                                el.TransactionFromBankId == mainSheet.Cells[i, 1].Value))
                            ;
                        if (transaction == null)
                        {
                            transaction = new Transaction();
                            await _unitOfWork.TransactionRepository.Insert(transaction);
                        }
                        transaction.TransactionFromBankId = (string)mainSheet.Cells[i, 1].Value;
                        transaction.CreatedDate = (DateTime)mainSheet.Cells[i, 2].Value;
                        transaction.Description = (string)mainSheet.Cells[i, 3].Value;
                        transaction.Sum = Convert.ToSingle((double)mainSheet.Cells[i, 4].Value);
                        transaction.CurrencyId = Convert.ToInt32((double)mainSheet.Cells[i, 5].Value);
                        transaction.CardId = new Guid((string)mainSheet.Cells[i, 6].Value);
                        await _unitOfWork.SaveChangesAsync();
                        //c
                    }


                }
            }
            return true;
        }
    }
}
