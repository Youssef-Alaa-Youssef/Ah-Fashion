using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Products;


namespace ShareEdu.Factory.DAL.Data.Configurations.ProductConfig
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes"); // Table name
            builder.HasKey(s => s.SizeID); // Primary key
            builder.Property(s => s.SizeID).HasColumnName("SizeID").IsRequired(); // Column name and required
            builder.Property(s => s.NameEn).HasMaxLength(50).IsRequired(); // Max length for NameEn
            builder.Property(s => s.NameAr).HasMaxLength(50).IsRequired(); // Max length for NameAr
            builder.Property(s => s.Symbol).HasMaxLength(10).IsRequired(); // Max length for Symbol
        }
    }
}
