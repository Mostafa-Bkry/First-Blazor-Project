using System.ComponentModel.DataAnnotations;

namespace Day2.Models
{
    public class Product
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Must be between 6 and 150 characters")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Must be between 6 and 150 characters")]
        public string Description { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression("^.*\\.(png|jpe?g)$")]
        public string Image { get; set; }

        public int CatgID { get; set; }
    }
}
