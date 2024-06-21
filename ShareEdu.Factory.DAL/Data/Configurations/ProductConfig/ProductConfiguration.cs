using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Products;

namespace ShareEdu.Factory.DAL.Data.Configurations.ProductConfig
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); 
            builder.HasKey(p => p.ID); 
            builder.Property(p => p.ID).HasColumnName("ProductID").IsRequired(); 
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(); // Max length for Name
            builder.Property(p => p.Description).IsRequired(false); // Description is optional
            builder.Property(p => p.Expire).HasColumnType("date").IsRequired(); // Date type for Expire

            // Define Size relationship
            builder.HasOne(p => p.Size)
                   .WithMany()
                   .HasForeignKey(p => p.SizeID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of Size if Product exists
        }
    }
}
