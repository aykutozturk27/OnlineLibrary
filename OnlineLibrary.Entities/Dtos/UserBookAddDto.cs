using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.Entities.Dtos
{
    public class UserBookAddDto : IDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Stock { get; set; }//stok adedi
        public DateTime ReservedDate { get; set; }//rezervasyon tarihi
        public DateTime? ReturnedDate { get; set; }//teslim tarihi
        public int UserId { get; set; }
    }
}
