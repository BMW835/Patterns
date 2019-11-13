using Hw4.Models;

namespace Hw4.Clients
{
    public interface IOrmAdapter // ITarget
    {
        (DbUserEntity, DbUserInfoEntity) Get(int userId);
    }
}