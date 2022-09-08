using System.ComponentModel.DataAnnotations;

namespace Core.Entities.SubscriptionEntity
{
    public class SubscriptionsSearch
    {
        [Key]
        public Guid Id { get; set; }
        //public int SubscriptionSearchId { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
        //public int? SubscriptionsListId { get; set; }
        //Navigation properties
        public virtual Service Service { get; set; }
    }
}
