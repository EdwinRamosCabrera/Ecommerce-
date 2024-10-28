using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_.Models
{   
    [Table("Categorias")]
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

    }
}