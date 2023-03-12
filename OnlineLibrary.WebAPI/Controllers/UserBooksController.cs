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
        private readonly ILogger<UserBooksController> _logger;

        public UserBooksController(IUserBookService userBookService, ILogger<UserBooksController> logger)
        {
            _userBookService = userBookService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _userBookService.GetAll();
            if (result.Success)
            {
                _logger.LogInformation("Kullanıcı kitapları listelendi");
                return Ok(result);
            }
            _logger.LogError("Kullanıcı kitapları listelenemedi");
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public ActionResult Add(UserBookAddDto userBookAddDto)
        {
            var result = _userBookService.Add(userBookAddDto);
            if (result.Success)
            {
                _logger.LogInformation("{0} adlı kitap eklendi." + userBookAddDto.Name);
                return Ok(result);
            }
            _logger.LogError("Kitap eklenemedi");
            return BadRequest(result);
        }

        [HttpGet("GetReservationBookList")]
        public ActionResult GetReservationBookList()
        {
            var result = _userBookService.GetReservationBookList();
            if (result.Success)
            {
                _logger.LogInformation("Reserve edilen kitaplar listelendi");
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
                _logger.LogInformation("İade edilen kitaplar listelendi");
                return Ok(result);
            }
            _logger.LogError("İade edilen kitaplar listelenemedi");
            return BadRequest(result);
        }
    }
}
