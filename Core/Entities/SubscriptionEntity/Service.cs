using Core.Entities.CategoryEntity;

namespace Core.Entities.SubscriptionEntity
{
    public class Service
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public Guid? ServiceCategoryId { get; set; }
        public Guid? ServiceSubCategoryId { get; set; }
        //public int? CountUser { get; set; }
        //public int? UserId { get; set; }
        //Navigation properties
        public virtual ServiceCategory ServiceCategory { get; set; }
        public virtual ServiceSubCategory ServiceSubCategory { get; set; }

    }
}
