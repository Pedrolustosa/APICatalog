using System.ComponentModel.DataAnnotations;

namespace APICatalog.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Imagem")]
        public string? ImageURL { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
