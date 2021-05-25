using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage ="El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Cantidad es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        [Display(Name = "Precio")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "La Fecha es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Modf.")]
        public DateTime Fecha_Modificacion { get; set; }
    }
}
