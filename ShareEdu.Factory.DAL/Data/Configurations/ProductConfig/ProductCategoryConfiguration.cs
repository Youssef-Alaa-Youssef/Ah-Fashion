using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Data.Configurations.ProductConfig
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories"); // Table name
            builder.HasKey(pc => pc.Id); // Primary key
            builder.Property(pc => pc.Id).HasColumnName("CategoryID").IsRequired(); // Column name and required
            builder.Property(pc => pc.NameEn).HasMaxLength(100).IsRequired(); // Max length for NameEn
            builder.Property(pc => pc.NameAr).HasMaxLength(100).IsRequired(); // Max length for NameAr
            builder.Property(pc => pc.Description).IsRequired(false); // Description is optional

            builder.HasData(
                new ProductCategory { Id = 1, NameEn = "Men", NameAr = "رجالي", Description = "Products for Men" ,ImagePath = ""},
                new ProductCategory { Id = 2, NameEn = "Women", NameAr = "نسائي", Description = "Products for Women", ImagePath = ""},
                new ProductCategory { Id = 3, NameEn = "Kids", NameAr = "أطفال", Description = "Products for Kids", ImagePath = "" }
            );
        }
    }
}
