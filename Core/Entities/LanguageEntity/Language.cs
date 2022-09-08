using System.ComponentModel.DataAnnotations;

namespace Core.Entities.LanguageEntity
{
    public class Language
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SmallName { get; set; }
    }
}
