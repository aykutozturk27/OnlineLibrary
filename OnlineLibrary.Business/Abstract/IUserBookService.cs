using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Results.Abstract;

namespace OnlineLibrary.Business.Abstract
{
    public interface IUserBookService
    {
        IDataResult<List<UserBook>> GetAll();
        IResult Add(UserBook userBook);
    }
}
