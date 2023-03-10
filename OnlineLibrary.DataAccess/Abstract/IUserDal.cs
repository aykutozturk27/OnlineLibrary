using OnlineLibrary.Core.DataAccess;
using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
