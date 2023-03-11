using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Core.Entities;

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

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _userBookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public ActionResult Add(UserBook userBook)
        {
            var result = _userBookService.Add(userBook);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
