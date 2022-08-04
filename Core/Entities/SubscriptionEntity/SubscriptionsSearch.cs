using System.ComponentModel.DataAnnotations;

namespace Core.Entities.SubscriptionEntity
{
    public class SubscriptionsSearch
    {
        [Key]
        public int SubscriptionSearchId { get; set; }
        public string? Name { get; set; }
        public int? SubscriptionsListId { get; set; }
    }
}
