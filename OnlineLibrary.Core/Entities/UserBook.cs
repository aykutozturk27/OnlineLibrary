namespace OnlineLibrary.Core.Entities
{
    public class UserBook : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Stock { get; set; }//stok adedi
        public DateTime ReservedDate { get; set; }//rezervasyon tarihi
        public DateTime? ReturnedDate { get; set; }//teslim tarihi

        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
