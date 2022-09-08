using System.ComponentModel.DataAnnotations;
using Core.Entities.LanguageEntity;

namespace Core.Entities.BillingCycleEntity
{
    public class BillingCycle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? LangId { get; set; }
        public virtual Language Language { get; set; }
    }
}
