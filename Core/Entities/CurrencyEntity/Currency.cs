using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CurrencyEntity
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string? Flag { get; set; }
        public int CountUser { get; set; }
    }
}
