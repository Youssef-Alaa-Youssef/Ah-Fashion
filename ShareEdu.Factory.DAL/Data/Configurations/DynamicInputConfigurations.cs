using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Employment;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    public class DynamicInputConfigurations : IEntityTypeConfiguration<DynamicInput>
    {
        public void Configure(EntityTypeBuilder<DynamicInput> builder)
        {
            builder.ToTable("DynamicInputs");

            // Primary key
            builder.HasKey(di => di.Id);

            // Identity column configuration
            builder.Property(di => di.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Other property configurations
            builder.Property(di => di.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(di => di.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(di => di.IsRequired)
                .IsRequired();

            // Define foreign key relationships
            builder.HasOne(di => di.Job)
                .WithMany(j => j.DynamicInputs) // One-to-many relationship with Jobs
                .HasForeignKey(di => di.JobId) // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Adjust deletion behavior as needed

            builder.HasOne(di => di.JobCategory)
                .WithMany() // One-to-many relationship with JobCategory
                .HasForeignKey(di => di.JobCategoryId) // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Adjust deletion behavior as needed
        }
    }
}
