using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalog.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Imagem")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Imagem")]
        public string? ImageURL { get; set; }

        [Display(Name = "Estoque")]
        public float Inventory { get; set; }

        public DateTime CreationDate { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public Category? Category { get; set; }
    }
}
