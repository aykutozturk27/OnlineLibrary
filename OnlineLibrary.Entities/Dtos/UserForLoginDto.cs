using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
