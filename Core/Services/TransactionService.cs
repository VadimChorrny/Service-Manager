using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Transactions;
using Core.Entities.TransactionEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using OfficeOpenXml;

namespace Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactionsBySubscription(Guid id)
        {
            var subscription = await _unitOfWork.SubscriptionRepository.GetById(id);
            return _mapper.Map<IEnumerable<TransactionDTO>>(subscription.Transactions);
            //throw new NotImplementedException();
        }

        public Task<TransactionDTO> GetTransactionById(string transactionId)
        {
            throw new NotImplementedException();
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
                        Transaction transaction = (await _unitOfWork.TransactionRepository.Get(el =>
                                el.TransactionFromBankId != null &&
                                el.TransactionFromBankId == mainSheet.Cells[i, 1].Value))
                            .FirstOrDefault();
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
