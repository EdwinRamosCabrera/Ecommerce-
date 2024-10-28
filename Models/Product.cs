using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_.Models
{   
    [Table("Productos")]
    public class Product
    {   
        public int ProductId { get; set; }

        public string ProductCodigo { get; set; }

        public string ProductName { get; set; } 

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public bool ProductStatus { get; set; }

        public DateTime ProductCreationDate { get; set; }
    }
}