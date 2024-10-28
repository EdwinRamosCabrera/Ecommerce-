using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_.Models
{   
    public class Contact
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContactId { get; set; }

        [Required (ErrorMessage = "El campo Nombres es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo no puede tener mas de 30 caracteres")]
        [Column("Nombres")]
        public string ContactName { get; set; }

        [Required (ErrorMessage = "El campo Apellidos es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo no puede tener mas de 150 caracteres")]
        [Column("Apellidos")]
        public string ContactLastName { get; set; }

        [Required (ErrorMessage = " El campo Correo es requerido")]
        [EmailAddress (ErrorMessage = "El formato del correo electrónico es inválido")]
        [Column("Correo")]
        public string ContactEmail { get; set; }

        [StringLength (12, ErrorMessage = "El campo Teléfono no puede exceder los 12 caracteres")]
        [Column("Telefono")]
        public string? ContactPhone { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column("Fecha")]
        public DateTime ContactDate { get; set;}

        [Required (ErrorMessage = "El campo Mensaje es obligatorio")]
        [StringLength(300, ErrorMessage = "El campo no puede tener mas de 300 caracteres")]
        [Column("Mensaje")]
        public string ContactMessage { get; set; }
    }
}