using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Monobank;
using Core.DTOs.Subscriptions;
using Core.DTOs.Transactions;
using Core.Entities.BillingCycleEntity;
using Core.Entities.CardEntity;
using Core.Entities.CurrencyEntity;
using Core.Entities.Enums;
using Core.Entities.SubscriptionEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Newtonsoft.Json;

namespace Core.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        HttpClient client = new HttpClient();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task<SubscriptionResponseDTO> GetAllSubscriptionsFromMonobank(string token, AccountMonobankDTO accountMonobank, DateTime fromTime)
        {
            
            using (var message = new HttpRequestMessage(HttpMethod.Get, "https://api.monobank.ua/personal/statement/{account}/{from}/{to}"))
            {
                message.Headers.Add("X-Token", token);
                //message.Pa
            }
            return null;
            //throw new NotImplementedException();
        }

        public async Task RegisterSubscriptionsFromAccountsMonobank(IEnumerable<AccountMonobankDTO> accountsMonobank, string token, DateTime? fromDate, string userId)
        {

            var user = await _unitOfWork.UserRepository.GetById(userId);
            if (user == null) throw new HttpException($"User with id {userId} doesn`t exists", System.Net.HttpStatusCode.BadRequest);
            //return null;
            int unixTime;
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.AddDays(-31);
            }
            else if (fromDate.Value < DateTime.Now.AddDays(-31))
            {
                throw new HttpException("For monobank minimum date must be at least 31 days", System.Net.HttpStatusCode.BadRequest);
            }

            unixTime = fromDate.Value.ToUnixTime();
            UserBank userBank = (await _unitOfWork.UserBankRepository.Get((el => el.UserId == user.Id && el.BankId == 1))).FirstOrDefault();
            if (userBank == null)
            {
                userBank = new UserBank { BankId = 1, User = user, BankToken = token };
                await _unitOfWork.UserBankRepository.Insert(userBank);
            }
            else
            {
                userBank.BankToken = token;
            }
            

            foreach (var account in accountsMonobank)
            {
                Card card = userBank.Cards.FirstOrDefault(el => el.CardNumber == account.CardNumber.FirstOrDefault());
                if (card == null)
                {
                    card = new Card {CardNumber = account.CardNumber.FirstOrDefault()};
                    userBank.Cards.Add(card);
                }
                //user.Cards
                using (var message = new HttpRequestMessage(HttpMethod.Get, $"https://api.monobank.ua/personal/statement/{account.Id}/{unixTime}"))
                {
                    message.Headers.Add("X-Token", token);
                    var response = await client.SendAsync(message);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseData =
                            JsonConvert.DeserializeObject<List<TransactionMonobankResponseDTO>>(
                                await response.Content.ReadAsStringAsync());
                        foreach (var transactionDtoItem in responseData)
                        {
                            Currency currency = (await _unitOfWork.CurrencyRepository.Get((el) =>  el.CurrencyCode == transactionDtoItem.CurrencyCode)).FirstOrDefault();
                            if (currency == null)
                            {
                                throw new HttpException("Incorrect currency", System.Net.HttpStatusCode.BadRequest);
                            }

                            var transaction = new Transaction
                            {
                                Currency = currency,
                                CreatedDate = TimeHelper.UnixTimeStampToDateTime(transactionDtoItem.Time),
                                Description = transactionDtoItem.Description, Sum = transactionDtoItem.Amount, TransactionFromBankId  = transactionDtoItem.Id  
                            };
                            //user.Transactions.Add(transaction);
                            if (!card.Transactions.Any(el => el.Currency == currency && el.CreatedDate == transaction.CreatedDate && el.Description == transaction.Description))
                            {
                                card.Transactions.Add(transaction);
                            }
                            await _unitOfWork.SaveChangesAsync();

                        }
                        //user.Transactions.Append();
                    }
                    else
                    {
                        throw new HttpException($"Monobank API Error {response.Content.ReadAsStringAsync().Result}", System.Net.HttpStatusCode.BadRequest);
                    }
                    //user.Banks.Add();
                    //JsonConvert.
                    //return JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), new { accounts = new List<AccountMonobankDTO>() }).accounts;
                }
            }
            //return null;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubscriptionResponseDTO>> GetSubscriptions2(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId);
            if (user == null) throw new HttpException("User doesn`t exists", System.Net.HttpStatusCode.BadRequest);
            var transactions = user.Banks.SelectMany(el => el.Cards).SelectMany(el2 => el2.Transactions).OrderByDescending(el => el.CreatedDate).ToArray();//.Concat()//user.Banks.Join//user.Banks.Select(b => b.Cards.Select(c => c.Transactions));
            //var subscriptions = 
            //foreach (var trans in transactions)
            //{
                
            //}
            //var services = await _unitOfWork.ServiceRepository.Get();
            var subscriptionSearches = await _unitOfWork.SubscriptionsSearchRepository.Get(); 
            List<SubscriptionResponseDTO> result = new List<SubscriptionResponseDTO>();
            for (int i = 0; i < transactions.Count(); ++i)
            {
                for(int j=1; j < transactions.Length; ++j)
                //for (int j = transactions.Count() - 1; j > 0; j--)
                {
                    //int ad = transactions.Count();
                    //int ad2 = transactions.Length;
                    if (i != j)
                    {
                        var iElement = transactions[i];
                        var jElement = transactions[j];
                        //if (iElement.Description == "Webflow" && jElement.Description == "Webflow*TRIAL+123456111")
                        //{
                          
                        //}
                        if (iElement.Subscription == null || jElement.Subscription == null)
                        {
                            //bool isBillingCycle = false;
                            string billingCycle = null;
                            //if (iElement.Description.Contains("Sosiska") && jElement.Description.Contains("Sosiska"))
                            //{

                            //}
                            if (iElement.CurrencyId == jElement.CurrencyId)
                            {
                                if (IsMonthDifference(iElement.CreatedDate, jElement.CreatedDate, 5))
                                {
                                    billingCycle = "Monthly";
                                    //foreach (var service in services)
                                    //{
                                    //    if (service != null && transactions.ElementAt(i).Description.Contains(service.Name) &&
                                    //        transactions.ElementAt(j).Description.Contains(service.Name))
                                    //    {
                                    //        result.Add(new SubscriptionResponseDTO {ServiceName = service.Name});
                                    //    }
                                    //    ;
                                    //}
                                    //iElement.Sum

                                }
                                else if (IsYearDifference(iElement.CreatedDate, jElement.CreatedDate, 5))
                                {
                                    billingCycle = "Yearly";
                                    //++i;
                                    //j = 0;
                                }
                                else if (IsWeekDifference(iElement.CreatedDate, jElement.CreatedDate, 2))
                                {
                                    billingCycle = "Weekly";
                                }
                                else if (IsQuartalDifference(iElement.CreatedDate, jElement.CreatedDate, 10))
                                {
                                    billingCycle = "Quartaly";
                                }
                                else if (IsHalfYearDifference(iElement.CreatedDate, jElement.CreatedDate, 10))
                                {
                                    billingCycle = "Half-Yearly";
                                }
                            }
                            if (billingCycle != null)
                            {
                                //if (user.)
                                //{

                                //}
                                if (IsDescriptionSuitable(iElement.Description, jElement.Description) && IsPriceDifference(15, iElement.Sum, jElement.Sum))
                                {
                                    SubscriptionsSearch subscriptionsSearch = subscriptionSearches.FirstOrDefault(el =>
                                        iElement.Description.Contains(el.Name) ||
                                        jElement.Description.Contains(el.Name));
                                    //SearchField
                                    //Service service = services.FirstzOrDefault(el =>
                                    //    iElement.Description.Contains(el.Name) || jElement.Description.Contains(el.Name));
                                    Subscription subscription = null;
                                    bool isNewSubscription = false;
                                    if (iElement.Subscription == null && jElement.Subscription != null)
                                    {
                                        subscription = jElement.Subscription;
                                        subscription.Transactions.Add(iElement);
                                    }
                                    else if (jElement.Subscription == null && iElement.Subscription != null)
                                    {
                                        subscription = iElement.Subscription;
                                        subscription.Transactions.Add(jElement);
                                        
                                    }
                                    else
                                    {
                                        isNewSubscription = true;
                                        subscription = new Subscription();
                                        subscription.Transactions.Add(iElement);
                                        subscription.Transactions.Add(jElement);
                                        subscription.User = user;
                                    }
                                    ///Subscription
                                    if (subscriptionsSearch == null)
                                    {
                                        subscription.IsCustom = true;
                                        subscription.Name = iElement.Description;
                                    }
                                    else
                                    {
                                        subscription.IsCustom = false;
                                        subscription.Service = subscriptionsSearch.Service;
                                    }

                                    if (isNewSubscription)
                                    {
                                        await _unitOfWork.SubscriptionRepository.Insert(subscription);
                                    }
                                    else
                                    {
                                        _unitOfWork.SubscriptionRepository.Update(subscription);
                                    }
                                    
                                    BillingCycle billing = (await _unitOfWork.BillingCycleRepository.Get(el => el.Name == billingCycle)).FirstOrDefault();
                                    subscription.BillingCycle = billing;
                                    result.Add(new SubscriptionResponseDTO { ServiceName = transactions.ElementAt(i).Description, Date = iElement.CreatedDate, Date2 = jElement.CreatedDate, BillingCycle = billingCycle, IsCustom = true });
                                    
                                    await _unitOfWork.SaveChangesAsync();

                                    //await _unitOfWork.TransactionRepository.Delete()
                                    //++i;
                                    //j = 0;
                                }
                                //if (services != null && transactions.ElementAt(i).Description.Contains(service.Name) &&
                                //        transactions.ElementAt(j).Description.Contains(service.Name))

                            }
                            else
                            {
                                if (IsDescriptionSuitable(iElement.Description, jElement.Description))
                                {
                                    
                                    Transaction transactionWithSubscription = iElement.Subscription != null ? iElement : jElement.Subscription != null ? jElement : null;

                                    Transaction transactionWithoutSubscription = iElement.Subscription == null ? jElement : jElement.Subscription == null ? iElement : null;
                                    if (transactionWithSubscription != null && transactionWithoutSubscription != null &&  transactionWithoutSubscription.CreatedDate > transactionWithSubscription.CreatedDate )
                                    {
                                        var subscription = transactionWithSubscription.Subscription;
                                        subscription.BillingCycleId = 6;
                                        transactionWithoutSubscription.Subscription = subscription;
                                        await _unitOfWork.SaveChangesAsync();
                                    }
                                    //if (transaction != null)
                                    //{
                                    //    transaction.
                                    //}
                                    //transaction.Subscription
                                }
                                //bool IsOneHaveSubscription = iElement.Subscription != null  || jElement.Subscription //!= null ? // jElement.Subscription != null || iElement.Subscription != null;
                                //IsOneHaveSubscription
                                
                            }
                            //else if (iElement.Subscription != null)
                            //{

                            //}
                            //else if(jElement.Subscription == null && iElement.Subscription != null || iElement.Subscription == null && jElement.Subscription != null)
                            //{
                            //    var transactionWithoutSubscription = jElement.Subscription == null ? iElement : jElement;//?? iElement.Subscription;
                            //    if (IsDescriptionSuitable(iElement.Description, jElement.Description))
                            //    {
                            //        transactionWithoutSubscription.
                            //    }
                            //}
                        }
                        

                    }
                    ;
                }
            }
            //_unitOfWork.
            //var subscriptions = transactions.Where(s => s.Subscription != null).Select(s => s.Subscription).Distinct();//.GroupBy(t => t.Subscription).Select(x=> x.)//.Where(x => x.Subscription != null).Select(x => x.Subscription).;
            //foreach (var transaction in transactions)
            //{
            //    if (transaction.Subscription == null)
            //    {
            //        subscriptions.
            //    }
            //}

            return result;
        }

        public async Task<IEnumerable<SubscriptionResponseDTO>> GetSubscriptions(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId);
            if (user == null) throw new HttpException("User doesn`t exists", System.Net.HttpStatusCode.BadRequest);
            var transactions = user.Banks.SelectMany(el => el.Cards).SelectMany(el2 => el2.Transactions).OrderByDescending(el => el.CreatedDate).ToArray();//.Concat()//user.Banks.Join//user.Banks.Select(b => b.Cards.Select(c => c.Transactions));
            //var subscriptions = 
            //foreach (var trans in transactions)
            //{

            //}
            //var services = await _unitOfWork.ServiceRepository.Get();
            var subscriptionsSearches = (await _unitOfWork.SubscriptionsSearchRepository.Get()).ToArray();
            List<SubscriptionResponseDTO> result = new List<SubscriptionResponseDTO>();
            foreach (var transaction in transactions)
            {
                //if (transaction.Description)
                //{
                //var subscriptionsSearches = subscriptionSearches as SubscriptionsSearch[] ?? subscriptionSearches.ToArray();
                if (transaction.Subscription == null)
                {
                    SubscriptionsSearch subscriptionsSearch =
                        subscriptionsSearches.FirstOrDefault(el =>
                            IsDescriptionSuitable(el.Name, transaction.Description));
                    if (subscriptionsSearch != null)
                    {
                        var service = subscriptionsSearch.Service;
                        var subscription = transactions
                            .FirstOrDefault(el => el?.Subscription?.Service == service)
                            ?.Subscription;
                        if (subscription == null)
                        {
                            subscription = new Subscription {BillingCycleId = 6, IsCustom = false, Service = service};
                            await _unitOfWork.SubscriptionRepository.Insert(subscription);
                            subscription.Transactions.Add(transaction);
                            //subscription.Transactions.Add(transaction);
                        }
                        else
                        {
                            subscription.Transactions.Add(transaction);
                             _unitOfWork.SubscriptionRepository.Update(subscription);
                        }
                        //else
                        //{
                        //}
                    }
                    else
                    {
                        //byte countTransactionMainAdded = 0;
                        //bool isSubscription = false;
                        Subscription subscription = null;
                        foreach (var transactionCustom in transactions)
                        {
                            if (transactionCustom != transaction && transactionCustom.Subscription is {ServiceId: null})
                            {
                                if (IsDescriptionSuitable(transaction.Description, transactionCustom.Description))
                                {
                                    //isSubscription = true;
                                    //var
                                    subscription = transactions.FirstOrDefault(el => el.Subscription != null &&
                                            IsDescriptionSuitable(el.Subscription?.Name, transactionCustom.Description))
                                        ?.Subscription;
                                    if (subscription == null)
                                    {
                                        subscription= new Subscription { BillingCycleId = 6, IsCustom = true, Name = transaction.Description};
                                        await _unitOfWork.SubscriptionRepository.Insert(subscription);
                                    }

                                    subscription.Transactions?.Add(transactionCustom);
                                }
                            }
                        }
                        subscription?.Transactions?.Add(transaction);
                        //isSubscription ? 
                    }
                }

                //.Contains(el.Name)
                //}
                //transactions.Where(t => t.Description transaction.Description && t != transaction) 
                await _unitOfWork.SaveChangesAsync();
            }
            var groupedTransactions = transactions?.GroupBy(t => t.Subscription); //sorted
            foreach (var transactionsElement in groupedTransactions)
            {
                if (transactionsElement.Count() >= 2)
                {
                    var sortedTransactions = transactionsElement?.OrderByDescending(t => t.CreatedDate).ToArray();
                    if (sortedTransactions[0].CurrencyId == sortedTransactions[1].CurrencyId)
                    {
                        if (IsMonthDifference(sortedTransactions[0].CreatedDate, sortedTransactions[1].CreatedDate, 5))
                        {
                            sortedTransactions[0].Subscription.BillingCycleId = (int)BillingCycleEnum.Monthly;

                        }
                        else if (IsYearDifference(sortedTransactions[0].CreatedDate, sortedTransactions[1].CreatedDate, 5))
                        {
                            sortedTransactions[0].Subscription.BillingCycleId = (int)BillingCycleEnum.Yearly;
                        }
                        else if (IsWeekDifference(sortedTransactions[0].CreatedDate, sortedTransactions[1].CreatedDate, 2))
                        {
                            sortedTransactions[0].Subscription.BillingCycleId = (int)BillingCycleEnum.Weekly;
                        }
                        else if (IsQuartalDifference(sortedTransactions[0].CreatedDate, sortedTransactions[1].CreatedDate, 10))
                        {
                            sortedTransactions[0].Subscription.BillingCycleId = (int)BillingCycleEnum.Quarterly;
                        }
                        else if (IsHalfYearDifference(sortedTransactions[0].CreatedDate, sortedTransactions[1].CreatedDate, 10))
                        {
                            sortedTransactions[0].Subscription.BillingCycleId = (int)BillingCycleEnum.HalfYearly;
                        }
                    }
                }


            }
                
            await _unitOfWork.SaveChangesAsync();
            return null;
        }

        public async Task<IEnumerable<SubscriptionResponseDTO>> GetSubscriptionsByUser(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId);
            if (user == null) throw new HttpException("User doesn`t exists", System.Net.HttpStatusCode.BadRequest);
            var subscriptions = user.Banks.SelectMany(el => el.Cards).SelectMany(el2 => el2.Transactions).Select(el => el.Subscription);
            return _mapper.Map<IEnumerable<SubscriptionResponseDTO>>(subscriptions);
        }

        private bool IsDescriptionSuitable(string first, string second)
        {
            //String.To
            first = first.ToUpper();
            second = second.ToUpper();
            if (first.Contains(second) || second.Contains(first)) return true;
            string[] elementsFirst = first.Split('*', ' ', '.', ',');
            string[] elementsSecond = second.Split('*', ' ', '.', ',');
            elementsFirst = elementsFirst.Where(el => el.Length > 3).ToArray();
            elementsSecond = elementsSecond.Where(el => el.Length > 3).ToArray();
            return elementsFirst.Intersect(elementsSecond).Any();
            //return elementsFirst.SequenceEqual(elementsSecond);
            //elementsFirst.Select( el => el.Length > 3);
        }
        private bool IsQuartalDifference(DateTime from, DateTime to, int maxDayDifference)
        {
            return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 93));
        }
        private bool IsWeekDifference(DateTime from, DateTime to, int maxDayDifference)
        {
            return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 7));
        }
        private bool IsHalfYearDifference(DateTime from, DateTime to, int maxDayDifference)
        {
            return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 183));
        }
        private bool IsYearDifference(DateTime from, DateTime to, int maxDayDifference)
        {
            return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 365));
        }
        private bool IsPriceDifference(int percent, float price, float price2)
        {
            //float pricePercent = (price / 100 * percent);
            //return Math.Abs(pricePercent - price) >= price2;
            //return (price / 100 * percent)+price price2
            return Enumerable.Range(0, percent + 1).Contains(Convert.ToInt32(Math.Abs(((price2 - price) / Math.Abs(price)) * 100)));
        }
        private bool IsMonthDifference(DateTime from, DateTime to, int maxDayDifference)
        {
            //return Enumerable.Range(0, maxDayDifference)
            //    .Contains(from.Subtract(to).Days - DateTime.DaysInMonth(from.Year, from.Month)) || Enumerable
            //    .Range(0, maxDayDifference).Contains(to.Subtract(from).Days - DateTime.DaysInMonth(to.Year, to.Month));

            return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 31));
            //if ()
            //{
            //    Range r1 = 1..8;
            //}
        }
        //public static List<DateTime> GetMonthsBetween(DateTime from, DateTime to)
        //{
        //    if (from > to) return GetMonthsBetween(to, from);

        //    var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

        //    if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
        //    {
        //        monthDiff -= 1;
        //    }

        //    List<DateTime> results = new List<DateTime>();
        //    for (int i = monthDiff; i >= 1; i--)
        //    {
        //        results.Add(to.AddMonths(-i));
        //    }

        //    return results;
        //}

        public async Task<IEnumerable<AccountMonobankDTO>> GetMonobankAccounts(string token)
        {
            using (var message = new HttpRequestMessage(HttpMethod.Get, "https://api.monobank.ua/personal/client-info"))
            {
                message.Headers.Add("X-Token", token);
                var response = await client.SendAsync(message);
                //JsonConvert.
                return JsonConvert.DeserializeAnonymousType(await response.Content.ReadAsStringAsync(), new { accounts = new List<AccountMonobankDTO>()}).accounts;
            }
        }
        //public 
        public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
