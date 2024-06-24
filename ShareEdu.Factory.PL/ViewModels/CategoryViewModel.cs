namespace ShareEdu.Factory.PL.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePathFile { get; set; }
    }
}
