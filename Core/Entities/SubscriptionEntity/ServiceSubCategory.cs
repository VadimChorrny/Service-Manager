namespace Core.Entities.SubscriptionEntity
{
    public class ServiceSubCategory
    {
        public Guid Id { get; set; }
        //public int SubcategoryId { get; set; }
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? LangId { get; set; }
    }
}
