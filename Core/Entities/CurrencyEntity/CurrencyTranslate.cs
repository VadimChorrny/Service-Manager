using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CurrencyEntity
{
    public class CurrencyTranslate
    {
        [Key]
        public Guid Id { get; set; }
        public string? CurrencyTranslateName { get; set; }
        public Guid? LangId { get; set; }
    }
}
