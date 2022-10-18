using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Country;
using Core.DTOs.Language;

namespace Core.Interfaces.CustomServices
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetAllCountries();
    }
}
