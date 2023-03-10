using OnlineLibrary.Core.DataAccess;
using OnlineLibrary.Entities.Concrete;

namespace OnlineLibrary.DataAccess.Abstract
{
    public interface IUserBookDal : IEntityRepository<UserBook>
    {
    }
}
