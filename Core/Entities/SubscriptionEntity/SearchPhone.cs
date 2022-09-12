using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SubscriptionEntity
{
    public class SearchPhone
    {
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
