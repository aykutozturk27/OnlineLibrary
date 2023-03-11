using AutoMapper;
using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Business.BusinessAspects.Autofac;
using OnlineLibrary.Business.Constants;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Business;
using OnlineLibrary.Core.Utilities.Results.Abstract;
using OnlineLibrary.Core.Utilities.Results.Concrete;
using OnlineLibrary.DataAccess.Abstract;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.Business.Concrete.Managers
{
    public class UserBookManager : IUserBookService
    {
        private readonly IUserBookDal _userBookDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserBookManager(IUserBookDal userBookDal, IUserDal userDal = null, IMapper mapper = null)
        {
            _userBookDal = userBookDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        [SecuredOperation("userbook.list,admin")]
        public IDataResult<List<UserBook>> GetAll()
        {
            return new SuccessDataResult<List<UserBook>>(_userBookDal.GetList());
        }

        [SecuredOperation("userbook.add,admin")]
        public IResult Add(UserBookAddDto userBookAddDto)
        {
            IResult result = BusinessRules.Run(ReturnDateShouldBeAWeekAfterTheDay(userBookAddDto),
                UserIsNotAbleToRetrieveMoreThanThreeBooks(userBookAddDto), BookAlreadyExist(userBookAddDto));

            if (result != null)
            {
                return result;
            }

            var userBook = _mapper.Map<UserBook>(userBookAddDto);
            SetUserStockByAmount(userBook);

            var newUserBook = new UserBook
            {
                Name = userBook.Name,
                Amount = userBook.Amount,
                Stock = userBook.Stock,
                ReturnedDate = userBook.ReturnedDate,
                ReservedDate = userBook.ReservedDate,
                UserId = userBook.UserId
            };

            _userBookDal.Add(newUserBook);

            return new SuccessResult(userBook.Name + Messages.UserBookAdded);
        }

        public IDataResult<List<UserBook>> GetReservationBookList()
        {
            var reservationBooks = _userBookDal.GetList(ub => ub.ReservedDate != null);
            return new SuccessDataResult<List<UserBook>>(reservationBooks); 
        }

        public IDataResult<List<UserBook>> GetReturnedBookList()
        {
            var returnedBooks = _userBookDal.GetList(ub => ub.ReturnedDate != null);
            return new SuccessDataResult<List<UserBook>>(returnedBooks);
        }

        private UserBook SetUserStockByAmount(UserBook userBook)
        {
            var userBookCheck = _userBookDal.Get(u => u.Id == userBook.UserId);
            if (userBookCheck != null)
            {
                userBook.Stock = userBook.Stock - userBook.Amount;
            }
            return userBook;
        }

        private IResult ReturnDateShouldBeAWeekAfterTheDay(UserBookAddDto userBookAddDto)
        {
            var userBook = _mapper.Map<UserBook>(userBookAddDto);
            if (!userBook.ReturnedDate.HasValue)
            {
                userBook.ReturnedDate = userBook.ReservedDate.AddDays(7);
            }
            TimeSpan difference = Convert.ToDateTime(userBook.ReturnedDate) - Convert.ToDateTime(userBook.ReservedDate);
            if (difference.Days > 7)
            {
                return new ErrorResult(Messages.ReturnDateShouldBeAWeekAfterTheDay);
            }
            return new SuccessResult();
        }

        private IResult UserIsNotAbleToRetrieveMoreThanThreeBooks(UserBookAddDto userBookAddDto)
        {
            var userBook = _mapper.Map<UserBook>(userBookAddDto);
            if (userBook.ReturnedDate == null)
            {
                if (userBook.Amount > 3)
                {
                    return new ErrorResult(Messages.UserIsNotAbleToRetrieveMoreThanThreeBooks);
                }
            }
            return new SuccessResult();
        }

        private IResult BookAlreadyExist(UserBookAddDto userBookAddDto)
        {
            var userBook = _mapper.Map<UserBook>(userBookAddDto);
            var checkUserBook = _userBookDal.Get(ub => ub.Name == userBook.Name);

            if (checkUserBook != null)
            {
                return new ErrorResult(Messages.BookAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
