namespace Core.Entities.UserEntity
{
    public class UserBank
    {
        public int UserBankId { get; set; }
        public int? UserId { get; set; }
        public int? BankId { get; set; }
        public int? SynchronizationId { get; set; }
    }
}
