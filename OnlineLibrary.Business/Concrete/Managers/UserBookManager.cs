using OnlineLibrary.Business.Abstract;
using OnlineLibrary.DataAccess.Abstract;

namespace OnlineLibrary.Business.Concrete.Managers
{
    public class UserBookManager : IUserBookService
    {
        private readonly IUserBookDal _bookDal;

        public UserBookManager(IUserBookDal bookDal)
        {
            _bookDal = bookDal;
        }
    }
}
