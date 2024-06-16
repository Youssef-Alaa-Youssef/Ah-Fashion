using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareEdu.Factory.DAL.Models.Employment
{
    public class DynamicInput
    {
        public int Id { get; set; }

        public string Label { get; set; }

        [ForeignKey("InputType")]
        public int InputTypeId { get; set; }
        public virtual InputType InputType { get; set; }

        public bool IsVisible { get; set; }
        public bool IsRequired { get; set; }

        [ForeignKey("Job")]
        public Guid? JobId { get; set; } // Nullable foreign key for Job
        public virtual Jobs Job { get; set; } // Navigation property for Job

        [ForeignKey("JobCategory")]
        public int? JobCategoryId { get; set; } // Nullable foreign key for JobCategory
        public virtual JobCategory JobCategory { get; set; } // Navigation property for JobCategory

        public virtual ICollection<Option>? Options { get; set; } = new HashSet<Option>(); // Collection navigation property for options
    }
}
