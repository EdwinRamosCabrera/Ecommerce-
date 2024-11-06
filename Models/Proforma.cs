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
        public int ProformaId { get; set; }

        [Required]
        public int ProformaQuantity { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public string UserId { get; set; }

        public decimal ProformaSubtotal => ProformaQuantity * Product.ProductPrice;
    }
}