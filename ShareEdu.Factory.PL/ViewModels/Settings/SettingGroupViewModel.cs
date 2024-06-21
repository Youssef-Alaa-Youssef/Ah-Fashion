using System.ComponentModel.DataAnnotations;

namespace ShareEdu.Factory.PL.ViewModels.Settings
{
    public class SettingGroupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name must not exceed 255 characters")]
        public string Name { get; set; }

        [Display(Name = "Link Name (English)")]
        public string LinkNameEn { get; set; }

        [Display(Name = "Link Name (Arabic)")]
        public string LinkNameAr { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Visable { get; set; }
        public string Ranking { get; set; }
        public string Place { get; set; }
    }
}
