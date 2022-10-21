using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.BillingCycle;
using Core.DTOs.Service;

namespace Core.DTOs.Subscriptions
{
    public class SubscriptionResponseDTO
    {
        //public string ServiceName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        //public DateTime Date2 { get; set; }
        public bool IsCustom { get; set; } = true;

        public BillingCycleDTO BillingCycle { get; set; }
        public ServiceDTO Service { get; set; }
        //public string BillingCycle { get; set; }
    }
}
