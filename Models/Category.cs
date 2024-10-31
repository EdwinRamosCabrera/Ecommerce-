using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_.Models
{   
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CategoryId { get; set; }

        [Required (ErrorMessage = "El campo Código es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo permite hasta 10 caracteres")]
        [Column("Codigo")]
        public string CategoryCode { get; set; }

        [Required (ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El campo permite hasta 20 caracteres")]
        [Column("Nombre")]
        public string CategoryName { get; set; }

        [NotMapped]
        public ICollection<Product>? Products { get; set; }

    }
}