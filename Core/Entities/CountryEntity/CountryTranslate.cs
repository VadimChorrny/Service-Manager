using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CountryEntity
{
    public class CountryTranslate
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public Guid? LangId { get; set; }
    }
}
