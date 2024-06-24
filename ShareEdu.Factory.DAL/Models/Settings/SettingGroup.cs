using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareEdu.Factory.DAL.Models.Settings
{
    public class SettingGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkNameEn { get; set; }
        public string LinkNameAr { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Visable { get; set; } // Corrected property name to Visible
        public string ranking { get; set; } // Corrected property name to Ranking
        public string place { get; set; } // Corrected property name to Place
        public string Permission { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();

    }
}
