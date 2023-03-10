using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Abstract;

namespace OnlineLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBookService _userBookService;

        public UserBooksController(IUserBookService userBookService)
        {
            _userBookService = userBookService;
        }
    }
}
