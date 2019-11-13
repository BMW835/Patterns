using Hw4.Models.Interfaces;

namespace Hw4.Models
{
    public class DbUserEntity : IDbEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int InfoId { get; set; }
    }
}
