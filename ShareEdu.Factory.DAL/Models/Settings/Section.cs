using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Models.Settings
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public ICollection<Content> Sections { get; set; } = new HashSet<Content>();
    }
}
