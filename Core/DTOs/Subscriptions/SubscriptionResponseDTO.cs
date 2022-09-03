using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Subscriptions
{
    public class SubscriptionResponseDTO
    {
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Date2 { get; set; }
        public bool IsCustom { get; set; } = true;
        public string BillingCycle { get; set; }
    }
}
