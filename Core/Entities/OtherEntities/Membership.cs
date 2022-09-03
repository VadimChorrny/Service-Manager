using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Membership
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? LangId { get; set; }
        public int? Sum { get; set; }
    }
}
