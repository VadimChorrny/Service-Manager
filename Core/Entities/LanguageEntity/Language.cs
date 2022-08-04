using System.ComponentModel.DataAnnotations;

namespace Core.Entities.LanguageEntity
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string? Name { get; set; }
        public string? SmallName { get; set; }
    }
}
