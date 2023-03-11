namespace OnlineLibrary.Core.Entities
{
    public class UserBook : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
