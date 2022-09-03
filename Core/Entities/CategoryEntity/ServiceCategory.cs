using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CategoryEntity
{
    public class ServiceCategory
    {
        [Key]
        public Guid Id { get; set; }
        //public int CategoryId { get; set; }
        public string? Name { get; set; }
        public Guid? LangId { get; set; }
    }
}
