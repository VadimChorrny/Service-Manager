using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OtherEntities
{
    public class DateFormat
    {
        [Key]
        public Guid Id { get; set; }
        public string DateFormatName { get; set; }
    }
}


// convert to ENUM