using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.CountryEntity;
using Core.Entities.UserEntity;

namespace Core.Entities.BankEntity
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Links { get; set; }
        public string? LinksAPI { get; set; }
        //public int? CounterUser { get; set; }
        public string? InstructionTitle { get; set; }
        public string? InstructionDescription { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country {
            get;
            set;
        }
        public virtual ICollection<UserBank> UserBanks { get; set; } = new HashSet<UserBank>();
    }
}
