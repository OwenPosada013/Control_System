using System.ComponentModel.DataAnnotations;

namespace Control_System.Models
{
    public class ProductRegister
    {
        public int IdProductRegister { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1, 10000)]
        public int Cant { get; set; }
        public string? TypeProduct { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        [StringLength(100)]
        public string Provider { get; set; }

        [Required(ErrorMessage = "El porcentaje de IVA es obligatorio")]
        [Range(0, 100, ErrorMessage = "El IVA debe estar entre 0 y 100")]
        public decimal IVA { get; set; }
    }
}
