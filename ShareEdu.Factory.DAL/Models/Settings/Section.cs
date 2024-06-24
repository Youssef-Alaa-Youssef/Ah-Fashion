using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareEdu.Factory.DAL.Models.Settings
{
    public class Section
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Visible")]
        public bool Visable { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Setting Group")]
        public int? SettingGroupId { get; set; }    }
}
