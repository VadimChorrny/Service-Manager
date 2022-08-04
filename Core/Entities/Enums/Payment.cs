using System.ComponentModel;

namespace Core.Entities.Enums
{
    public enum Payment
    {
        [Description("Free trial")]
        FreeTrial,
        [Description("Unpaid")]
        Unpaid,
        [Description("Paid")]
        Paid
    }
}
