using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_.Models
{
    [Table("Detalle_Pedidos")]
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Detalle_Id")]
        public int ODetailsId { get; set; }

        [Required]
        [Column("Pedido_Id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [Column("Proforma_Id")]
        public int ProformaId { get; set; }
        public Proforma Proforma { get; set; }

        [Required]
        [Column("Producto_Nombre")]
        public string ProductoName { get; set; }

        [Required]
        [Column("Producto_Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Column("Producto_Precio")]
        public decimal UnitPrice { get; set; }

    }
}