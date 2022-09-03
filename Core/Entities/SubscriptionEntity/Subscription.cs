using Core.Entities.BillingCycleEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;

namespace Core.Entities.SubscriptionEntity
{
    public class Subscription
    {
        public Guid Id { get; set; }
        //public int SubscriptionId { get; set; }
        public Guid? ServiceId { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
        public Guid? StatusId { get; set; }
        public int BillingCycleId { get; set; }
        public Guid? RemindMeId { get; set; }
        public Guid? LabelId { get; set; }
        public string UserId { get; set; }
        public bool IsCustom { get; set; } // If user add custom subscription
        public virtual Service Service { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        public virtual User User { get; set; }
        public virtual BillingCycle BillingCycle { get; set; }
    }
}
