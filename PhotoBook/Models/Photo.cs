using System;
namespace PhotoBook.Models
{
    public class Photo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int UserId { get; set; }
    }
}
