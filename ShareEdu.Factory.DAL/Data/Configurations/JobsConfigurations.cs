using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Employment;

namespace ShareEdu.Factory.DAL.Configurations.Employment
{
    public class JobsConfiguration : IEntityTypeConfiguration<Jobs>
    {
        public void Configure(EntityTypeBuilder<Jobs> builder)
        {
            // Table name mapping
            builder.ToTable("Jobs");

            // Primary key
            builder.HasKey(j => j.Id);

            // Column mappings and configurations
            builder.Property(j => j.Id).HasColumnName("JobId").IsRequired();
            builder.Property(j => j.Title).IsRequired().HasMaxLength(255);
            builder.Property(j => j.Description).IsRequired();
            builder.Property(j => j.Responsibilities).IsRequired();
            builder.Property(j => j.Salary).HasColumnType("decimal(18,2)");
            builder.Property(j => j.Location).HasMaxLength(100);
            builder.Property(j => j.PostedDate).IsRequired();
            builder.Property(j => j.LastDateToApply).IsRequired();

            // Additional date properties
            builder.Property(j => j.AddTime).HasColumnName("AddTime").IsRequired();
            builder.Property(j => j.UpdateTime).HasColumnName("UpdateTime");
            builder.Property(j => j.DeleteTime).HasColumnName("DeleteTime");

            // Foreign key relationship mapping
            builder.HasOne(j => j.Category) // Each Job has one Category
                   .WithMany(c => c.Jobs) // Each Category can have many Jobs
                   .HasForeignKey(j => j.CategoryId) // Foreign key in Jobs table
                   .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior as needed
        }
    }
}
