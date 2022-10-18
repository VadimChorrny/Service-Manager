using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Constants;
using Core.Entities.CardEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class UserBankService: IUserBankService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBankService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterPrivat(string userId, string merchantId, string password, string cardNumber)
        {
            if (!await _unitOfWork.UserRepository.ExistsAsync(us => us.Id == userId))
            {
                throw new HttpException("User not found!", System.Net.HttpStatusCode.BadRequest);
            }
            var userBank = await _unitOfWork.UserBankRepository.GetFirstOrDefaultAsync( predicate: ub=> ub.UserId == userId && ub.BankId == (int)Bank.PRIVATBANK, include: source => source.Include(ub => ub.Cards),disableTracking: false);
            Card card = null;
            if (userBank == null)
            {
                userBank = new UserBank {BankId = (int) Bank.PRIVATBANK, UserId = userId};
                await _unitOfWork.UserBankRepository.Insert(userBank);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                card = userBank.Cards.FirstOrDefault((el) => el.CardNumber == cardNumber);
                
            }
            if (card == null)
            {
                card = new Card { CardNumber = cardNumber, UserBank = userBank };
                await _unitOfWork.CardRepository.Insert(card);
            }
            card.MerchantPassword = password;
            card.MerchantId = merchantId;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
