using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.Entities.Concrete
{
    public class UserBook : BaseEntity
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
