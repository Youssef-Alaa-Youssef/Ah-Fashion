// Location: ShareEdu.Factory.DAL.Data.Configurations.SectionsConfigurations.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Settings;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    internal class SectionsConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections"); // Optional: Set the table name if different

            // Primary key
            builder.HasKey(s => s.Id);

            // Properties
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Visable).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();

        }
    }
}
