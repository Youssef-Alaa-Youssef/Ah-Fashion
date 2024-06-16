using System;
using System.Collections.Generic;

namespace ShareEdu.Factory.DAL.Models.Employment
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddTime { get; private set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public virtual ICollection<Jobs> Jobs { get; set; } = new HashSet<Jobs>();

        public JobCategory()
        {
            AddTime = DateTime.UtcNow;
        }
    }
}
