using OnlineLibrary.Core.Entities;
using OnlineLibrary.Core.Utilities.Results.Abstract;
using OnlineLibrary.Core.Utilities.Security.JWT;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
