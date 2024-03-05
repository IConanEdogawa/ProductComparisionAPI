namespace LibraryManagement.Domain.Entities.DTOs
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public string? CategoryName { get; set; }
        public double Price { get; set; }
    }
}
