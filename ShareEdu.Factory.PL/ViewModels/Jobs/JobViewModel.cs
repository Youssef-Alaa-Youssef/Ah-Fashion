using System;
using System.ComponentModel.DataAnnotations;
using ShareEdu.Factory.DAL.Models.Employment; // Assuming namespace for JobCategory

namespace ShareEdu.Factory.PL.ViewModels.Jobs
{
    public class JobViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Responsibilities are required")]
        [Display(Name = "Responsibilities")]
        public string Responsibilities { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Is Opened")]
        public bool IsOpen { get; set; }
    }
}

