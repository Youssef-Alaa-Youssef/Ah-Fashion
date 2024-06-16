using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Models.Products
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly Expire { get; set; }

        [ForeignKey("Size")]
        public Size SizeID { get; set; }
        public Size Size { get; set; }

        public Product()
        {

        }
    }
}
