using System.ComponentModel;

namespace Core.Entities.Enums
{
    public enum PremiumMembership
    {
        [Description("Free Trial")]
        FREE_TRIAL,
        [Description("Monthly")]
        MONTHLY,
        [Description("Year")]
        YEAR
    }
}
