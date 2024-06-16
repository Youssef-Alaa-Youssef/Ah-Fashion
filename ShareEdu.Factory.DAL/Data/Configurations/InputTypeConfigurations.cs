using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Employment;
using System.Reflection.Emit;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    public class InputTypeConfigurations : IEntityTypeConfiguration<InputType>
    {
        public void Configure(EntityTypeBuilder<InputType> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new InputType { Id = 1, Name = "Text" },
                new InputType { Id = 2, Name = "TextArea" },
                new InputType { Id = 3, Name = "Email" },
                new InputType { Id = 4, Name = "Number" },
                new InputType { Id = 5, Name = "Checkbox" },
                new InputType { Id = 6, Name = "Date" },
                new InputType { Id = 7, Name = "Radio Button" }
            );
        }
    }
}
