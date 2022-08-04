using Core.Entities.CurrencyEntity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.TransactionEntity
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CategoryTitle { get; set; }
        public string? Payee { get; set; }
        public string? Card { get; set; }
        public string? Description { get; set; }
        public float? Sum { get; set; }
        public int? CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public int? SubscriptionId { get; set; }
        public int? CardId { get; set; }
    }
}
