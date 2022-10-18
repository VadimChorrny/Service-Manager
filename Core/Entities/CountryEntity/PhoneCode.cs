using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CountryEntity
{
    public class PhoneCode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
