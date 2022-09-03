using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Synchronization
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? LangId { get; set; }
    }
}
