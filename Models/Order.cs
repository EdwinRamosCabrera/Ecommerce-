using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_.Models
{   
    [Table("Pedidos")]
    public class Order
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }    

        [Required]
        [Column("Usuario")]
        public string UserId { get; set; }

        [Required]
        [Column("Monto_Total")]
        public decimal AmountTotal { get; set; }
        
        [Required]
        [Column("Pago_Id")]
        public int PaymentId { get; set; }
        public Payment? Payment { get; set; }    

        [Required]
        [Column("Estado")]
        public string Status { get; set; }
        
        [Required]
        [Column("Nombre")]
        public string Name { get; set; }

        [Required]
        [Column("Apellido")]
        public string LastName { get; set; } 

        [Required]
        [Column("Correo")]
        public string Email { get; set; }
        
        [Required]
        [Column("Teléfono")]
        public string Phone { get; set; }   

        [Required]
        [Column("Observaciones")]
        public string? Observations { get; set; }
        
    }
}