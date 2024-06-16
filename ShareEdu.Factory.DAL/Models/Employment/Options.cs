namespace ShareEdu.Factory.DAL.Models.Employment
{
    public class Option
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int DynamicInputId { get; set; }
        public virtual DynamicInput DynamicInput { get; set; }
    }
}
