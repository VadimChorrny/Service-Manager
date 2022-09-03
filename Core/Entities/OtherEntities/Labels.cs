using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class Labels
    {
        [Key]
        public Guid Id { get; set; }
        //public int LabelId { get; set; }
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
    }
}
