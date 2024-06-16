using ShareEdu.Factory.DAL.Models.Employment;

namespace ShareEdu.Factory.PL.ViewModels.Employment
{
    public class DynamicInputViewModel
    {
        public string Label { get; set; }
        public int InputTypeId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<OptionViewModel>? Options { get; set; } // Assuming OptionViewModel is defined correctly

        public Guid JobId { get; set; }
        public int JobCategoryId { get; set; }
    }
}
