using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public double Price { get; set; }
        public string CategoryName { get; set; }

    }
}
