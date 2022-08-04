using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CountryEntity
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string? Flag { get; set; }
    }
}
