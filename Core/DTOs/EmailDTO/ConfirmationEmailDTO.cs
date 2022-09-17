using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.EmailDTO
{
    public class ConfirmationEmailDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Link { get; set; }
    }
}
