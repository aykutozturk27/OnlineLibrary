using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Entities.Dtos;

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

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _userBookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public ActionResult Add(UserBookAddDto userBookAddDto)
        {
            var result = _userBookService.Add(userBookAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetReservationBookList")]
        public ActionResult GetReservationBookList()
        {
            var result = _userBookService.GetReservationBookList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetReturnedBookList")]
        public ActionResult GetReturnedBookList()
        {
            var result = _userBookService.GetReturnedBookList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
