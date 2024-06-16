using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Employment;

namespace ShareEdu.Factory.DAL.Configurations.Employment
{
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            // Table name
            builder.ToTable("JobCategories");

            // Primary key
            builder.HasKey(jc => jc.Id);

            // Column configurations
            builder.Property(jc => jc.Id).HasColumnName("CategoryId").IsRequired();
            builder.Property(jc => jc.Name).HasColumnName("CategoryName").IsRequired().HasMaxLength(100);

            // Relationships
            builder.HasMany(jc => jc.Jobs) // One JobCategory has many Jobs
                   .WithOne(j => j.Category) // Each Job belongs to one JobCategory
                   .HasForeignKey(j => j.CategoryId) // Foreign key in Jobs table
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete if needed

            // Seed data
            builder.HasData(
                new JobCategory { Id = 1, Name = "Software Development" },
                new JobCategory { Id = 2, Name = "Marketing" },
                new JobCategory { Id = 3, Name = "Finance" }
            );
        }
    }
}
