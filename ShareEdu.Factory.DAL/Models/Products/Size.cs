using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Models.Products
{
    public class Size
    {
        public int SizeID { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;

    }
}
