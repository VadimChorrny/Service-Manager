using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.CurrencyEntity
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string? Flag { get; set; }
        [Required]
        //[AlternateKey]
        //[Index(IsUnique = true)]
        [MaxLength(10)]
        //[Index("CurrencyCode",1, IsUnique = true)]
        public string CurrencyCode { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string LettersSign { get; set; }
        //public int CountUser { get; set; } the field can be retrieved from the query
    }
}
