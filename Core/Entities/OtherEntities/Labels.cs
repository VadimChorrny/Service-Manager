using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Labels
    {
        [Key]
        public int LabelId { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }
    }
}
