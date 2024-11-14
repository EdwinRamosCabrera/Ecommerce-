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
        [Column("Id")]
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
        public string State { get; set; }
        
        [Required (ErrorMessage = "El campo Nombre es obligatorio")]
        [Column("Nombre")]
        public string Name { get; set; }

        [Required (ErrorMessage = "El campo Apellido es obligatorio")]
        [Column("Apellido")]
        public string LastName { get; set; } 

        [Required (ErrorMessage = "El campo Correo es obligatorio")]
        [Column("Correo")]
        public string Email { get; set; }
        
        [Required (ErrorMessage = "El campo Teléfono es obligatorio")]
        [Column("Teléfono")]
        public string Phone { get; set; }   

        [Column("Dirección")]
        public string? Address { get; set; } 

        [Column("Observaciones")]
        public string? Observations { get; set; }
        
    }
}