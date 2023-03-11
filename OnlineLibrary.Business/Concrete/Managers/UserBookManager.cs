using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Business.BusinessAspects.Autofac;
using OnlineLibrary.Business.Constants;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Results.Abstract;
using OnlineLibrary.Core.Utilities.Results.Concrete;
using OnlineLibrary.DataAccess.Abstract;

namespace OnlineLibrary.Business.Concrete.Managers
{
    public class UserBookManager : IUserBookService
    {
        private readonly IUserBookDal _userBookDal;

        public UserBookManager(IUserBookDal userBookDal)
        {
            _userBookDal = userBookDal;
        }

        [SecuredOperation("userbook.list,admin")]
        public IDataResult<List<UserBook>> GetAll()
        {
            return new SuccessDataResult<List<UserBook>>(_userBookDal.GetList());
        }

        [SecuredOperation("userbook.add,admin")]
        public IResult Add(UserBook userBook)
        {
            _userBookDal.Add(userBook);

            return new SuccessResult(Messages.UserBookAdded);
        }
    }
}
