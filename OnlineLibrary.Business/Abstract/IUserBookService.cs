using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Results.Abstract;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.Business.Abstract
{
    public interface IUserBookService
    {
        IDataResult<List<UserBook>> GetAll();
        IResult Add(UserBookAddDto userBookAddDto);
        IDataResult<List<UserBook>> GetReservationBookList();//rezerve ettiği kitap listesi
        IDataResult<List<UserBook>> GetReturnedBookList();//teslim edilen kitap listesi

    }
}
