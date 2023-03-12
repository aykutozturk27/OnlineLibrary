using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Abstract;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                _logger.LogError("{0} adlı kullanıcı bulunamadı", userForLoginDto.FirstName);
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                _logger.LogInformation("{0} adlı kullanıcı giriş yaptı", userForLoginDto.FirstName);
                return Ok(result.Data);
            }

            _logger.LogError("Kullanıcı giriş işlemi başarısız");
            return BadRequest(result.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                _logger.LogError("{0} adlı kullanıcı zaten var", userForRegisterDto.FirstName);
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                _logger.LogInformation("{0} adlı kullanıcı kayıt oldu", userForRegisterDto.FirstName);
                return Ok(result.Data);
            }

            _logger.LogError("Kullanıcı kayıt işlemi başarısız");
            return BadRequest(result.Message);
        }
    }
}
