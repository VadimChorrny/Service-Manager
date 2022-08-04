namespace Core.Entities.SubscriptionEntity
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? LangId { get; set; }
    }
}
