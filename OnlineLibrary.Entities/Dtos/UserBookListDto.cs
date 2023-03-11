using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.Entities.Dtos
{
    public class UserBookListDto : IDto
    {
        public IList<UserBook> UserBooks { get; set; }
    }
}
