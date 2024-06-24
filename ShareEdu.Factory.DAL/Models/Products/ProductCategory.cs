
namespace ShareEdu.Factory.DAL.Models.Products
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; } 
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
