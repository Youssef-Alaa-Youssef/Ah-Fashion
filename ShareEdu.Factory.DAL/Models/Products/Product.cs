using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Models.Products
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly Expire { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual ProductCategory Category { get; set; }

        [ForeignKey("Size")]
        public int SizeID { get; set; }
        public virtual Size Size { get; set; }
    }
}
