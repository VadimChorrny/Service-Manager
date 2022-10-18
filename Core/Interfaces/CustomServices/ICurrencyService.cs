using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.CurrencyDTO;

namespace Core.Interfaces.CustomServices
{
    public interface ICurrencyService
    {
        Task<CurrencyDTO> GetById(int id);
    }
}
