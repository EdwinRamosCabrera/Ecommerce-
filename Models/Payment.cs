using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_.Models
{
    [Table("Pagos")]
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        public int PaymentId { get; set; }

        [Column("Usuario")]
        [Required (ErrorMessage = "El campo User es obligatorio")]
        public string UserId { get; set; }

        [Required (ErrorMessage = "El campo Nombre de la Tarjeta es obligatorio")]
        [Column("Nombre_Tarjeta")]
        public string NameCard { get; set; }

        [NotMapped]
        public string NumberCard { get; set; }
        
        [NotMapped]
        public string DueDateYYMM {get; set; }

        [NotMapped]
        public string Cvv {get; set;}

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column("Fecha_Pago")]
        public DateTime DatePay { get; set; }

        [Required]
        [Column("Monto_Total")]
        public decimal AmountTotal { get; set; }

        [Column("Observaciones")]
        public string? Observations { get; set; }
    }
}