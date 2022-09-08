using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Status
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? LangId { get; set; }
    }
}
