using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IServiceService
    {
        Task<bool> SaveFromExcel(string path);
    }
}
