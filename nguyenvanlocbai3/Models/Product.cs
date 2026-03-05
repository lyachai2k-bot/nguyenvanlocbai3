using System.ComponentModel.DataAnnotations;

namespace nguyenvanlocbai3.Models
{
    public class Product
    {

        [Required]

        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public string? Description { get; set; }
    }

}
