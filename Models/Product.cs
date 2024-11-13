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
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo Código es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo permite hasta 10 caracteres")]
        [Column("Codigo")]
        public string Code { get; set; }
        
        [Required (ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo permite hasta 30 caracteres")]
        [Column("Nombre")]
        public string Name { get; set; } 


        [Required (ErrorMessage = "El campo Imagen es obligatorio")]
        [Column("Imagen")]
        public string Image { get; set; }

        [Required (ErrorMessage = "El campo Descripción es obligatorio")]
        [StringLength(300, ErrorMessage = "El campo permite hasta 300 caracteres")]
        [Column("Descripcion")]
        public string Description { get; set; }

        [Required (ErrorMessage = "El campo Precio es obligatorio")]
        [Column("Precio")]
        public decimal Price { get; set; }

        [Column("Estado")]
        public string State { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column("Fecha")]
        public DateTime CreationDate { get; set;}

        [Required (ErrorMessage = "El campo Categoria es obligatorio")]
        [Column("Categoria_Id")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Proforma>? Proformas { get; set; }

        public Product()
        {
                CreationDate = DateTime.UtcNow;
                State = "INACTIVO";
        }
    }
}