using Core.Entities.CurrencyEntity;
using System.ComponentModel.DataAnnotations;
using Core.Entities.CardEntity;

namespace Core.Entities.TransactionEntity
{
    public class Transaction
    {
        [Key] 
        public Guid Id { get; set; }
        public string TransactionFromBankId { get; set; }
        //public int TransactionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryTitle { get; set; }
        //public string? Payee { get; set; }
        //public string? Card { get; set; }
        public string Description { get; set; }
        public float Sum { get; set; }
        public int CurrencyId { get; set; }
        public Guid CardId { get; set; }
        //public Guid? SubscriptionId { get; set; }
        //public Guid? CardId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Card Card { get; set; }
    }
}
