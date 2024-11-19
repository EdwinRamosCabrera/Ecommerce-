using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_.Models
{
    public class Proforma
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        public int ProformaId { get; set; }

        [Required]
        [Column("Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Column("Producto_Id")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Column("Precio")]
        public decimal Price { get; set; }

        [Required]
        [Column("Estado")]
        public string State { get; set; } = "PENDIENTE";

        [Required]
        [Column("Usuario")]
        public string UserId { get; set; }

        public decimal Subtotal => Quantity * Price;
    }
}