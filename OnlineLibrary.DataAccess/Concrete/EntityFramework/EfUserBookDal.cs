using OnlineLibrary.Core.DataAccess.EntityFramework;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.DataAccess.Abstract;
using OnlineLibrary.DataAccess.Concrete.EntityFramework.Contexts;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfUserBookDal : EfEntityRepositoryBase<UserBook, OnlineLibraryContext>, IUserBookDal
    {
    }
}
