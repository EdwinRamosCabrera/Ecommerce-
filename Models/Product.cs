using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_.Models
{   
    public class Product
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        public int ProductId { get; set; }

        [Required (ErrorMessage = "El campo Código es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo permite hasta 10 caracteres")]
        [Column("Codigo")]
        public string ProductCode { get; set; }
        
        [Required (ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo permite hasta 30 caracteres")]
        [Column("Nombre")]
        public string ProductName { get; set; } 


        [Required (ErrorMessage = "El campo Imagen es obligatorio")]
        [Column("Imagen")]
        public string ProductImage { get; set; }

        [Required (ErrorMessage = "El campo Descripción es obligatorio")]
        [StringLength(300, ErrorMessage = "El campo permite hasta 300 caracteres")]
        [Column("Descripcion")]
        public string ProductDescription { get; set; }

        [Required (ErrorMessage = "El campo Precio es obligatorio")]
        [Column("Precio")]
        public decimal ProductPrice { get; set; }

        [Column("Estado")]
        public bool ProductStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column("Fecha")]
        public DateTime ProductCreationDate { get; set;}

        [Required (ErrorMessage = "El campo Categoria es obligatorio")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public Product()
        {
                ProductCreationDate = DateTime.UtcNow;
        }
    }
}