using OnlineLibrary.Core.DataAccess.EntityFramework;
using OnlineLibrary.DataAccess.Abstract;
using OnlineLibrary.DataAccess.Concrete.EntityFramework.Contexts;
using OnlineLibrary.Entities.Concrete;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfUserBookDal : EfEntityRepositoryBase<UserBook, OnlineLibraryContext>, IUserBookDal
    {
    }
}
