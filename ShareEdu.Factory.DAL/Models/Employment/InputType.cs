using System.ComponentModel.DataAnnotations;

namespace ShareEdu.Factory.DAL.Models.Employment
{
    public class InputType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } 

        public bool IsVisible { get; set; }

        public virtual ICollection<DynamicInput> DynamicInputs { get; set; } = new HashSet<DynamicInput>();
    }
}
