using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.PhoneCode;

namespace Core.DTOs.Country
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public IEnumerable<PhoneCodeDTO> PhoneCodes { get; set; }
    }
}
