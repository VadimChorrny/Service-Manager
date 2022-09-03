using System.ComponentModel.DataAnnotations;
using Core.Entities.BankEntity;
using Core.Entities.CardEntity;

namespace Core.Entities.UserEntity
{
    public class UserBank
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public Guid? SynchronizationId { get; set; }
        public string BankToken { get; set; }
        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}
