using Core.Entities.UserEntity;

namespace Core.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
