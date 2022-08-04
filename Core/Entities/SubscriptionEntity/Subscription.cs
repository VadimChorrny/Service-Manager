namespace Core.Entities.SubscriptionEntity
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int? SubscriptionsListId { get; set; }
        public string? Notes { get; set; }
        public int? StatusId { get; set; }
        public int? BillingCycleId { get; set; }
        public int? RemindMeId { get; set; }
        public int? LabelId { get; set; }
        public int? UserId { get; set; }
    }
}
