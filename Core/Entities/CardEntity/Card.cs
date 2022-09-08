using System.ComponentModel.DataAnnotations;
using Core.Entities.BankEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;

namespace Core.Entities.CardEntity
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        //public string BankId { get; set; }
        //public virtual Bank Bank { get; set; }
        public Guid? UserBankId { get; set; }
        public virtual UserBank UserBank { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
