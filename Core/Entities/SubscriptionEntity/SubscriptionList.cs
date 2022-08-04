namespace Core.Entities.SubscriptionEntity
{
    public class SubscriptionList
    {
        public int SubscriptionListId { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? CountUser { get; set; }
        public int? UserId { get; set; }

    }
}
