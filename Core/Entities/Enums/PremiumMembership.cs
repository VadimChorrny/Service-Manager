using System.ComponentModel;

namespace Core.Entities.Enums
{
    public enum PremiumMembership
    {
        [Description("Free Trial")]
        FreeTrial,
        [Description("Monthly")]
        Monthly,
        [Description("Year")]
        Year
    }
}
