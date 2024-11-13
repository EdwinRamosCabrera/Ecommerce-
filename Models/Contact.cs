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
    public class Contact
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo Nombres es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo no puede tener mas de 30 caracteres")]
        [Column("Nombres")]
        public string Name { get; set; }

        [Required (ErrorMessage = "El campo Apellidos es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo no puede tener mas de 150 caracteres")]
        [Column("Apellidos")]
        public string LastName { get; set; }

        [Required (ErrorMessage = " El campo Correo es requerido")]
        [EmailAddress (ErrorMessage = "El formato del correo electrónico es inválido")]
        [Column("Correo")]
        public string Email { get; set; }

        [StringLength (12, ErrorMessage = "El campo Teléfono no puede exceder los 12 caracteres")]
        [Column("Telefono")]
        public string? Phone { get; set; }

        [Required (ErrorMessage = "El campo Mensaje es obligatorio")]
        [StringLength(300, ErrorMessage = "El campo no puede tener mas de 300 caracteres")]
        [Column("Mensaje")]
        public string Message { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column("Fecha")]
        public DateTimeOffset Date { get; set;} 

        public Contact()
        {
                Date = DateTimeOffset.UtcNow;
        }
    }
}