using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Language;

namespace Core.Interfaces.CustomServices
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageDTO>> GetAllLanguages();
    }
}
