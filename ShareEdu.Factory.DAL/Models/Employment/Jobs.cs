using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareEdu.Factory.DAL.Models.Employment
{
    public class Jobs
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
        public decimal? Salary { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime LastDateToApply { get; set; }

        public bool IsOpen { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual JobCategory Category { get; set; } // Navigation property for JobCategory

        public virtual ICollection<DynamicInput> DynamicInputs { get; set; } = new HashSet<DynamicInput>(); // Collection navigation property for DynamicInput entities

        // Date properties
        public DateTime AddTime { get; private set; }
        public DateTime? UpdateTime { get; private set; }
        public DateTime? DeleteTime { get; private set; }

        public Jobs()
        {
            AddTime = DateTime.UtcNow;
        }
    }
}
