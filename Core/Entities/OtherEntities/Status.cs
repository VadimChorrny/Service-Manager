using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string? Name { get; set; }
        public int? LangId { get; set; }
    }
}
