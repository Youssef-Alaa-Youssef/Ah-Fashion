using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    internal class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.ToTable("Websites"); // Table name

            builder.HasKey(w => w.Id); // Primary key

            builder.Property(w => w.Id)
                   .HasColumnName("Id")
                   .IsRequired(); // Column name and required

            builder.Property(w => w.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired(); // Name column, max length 100, required

            builder.Property(w => w.Domain)
                   .HasColumnName("Domain")
                   .HasMaxLength(100)
                   .IsRequired(); // Domain column, max length 100, required

            builder.Property(w => w.CompanyName)
                   .HasColumnName("CompanyName"); // CompanyName column, optional

            builder.Property(w => w.Now)
                   .HasColumnName("Now"); // Now column, optional DateTime

            builder.Property(w => w.IsVisible)
                   .HasColumnName("IsVisible")
                   .IsRequired(); // IsVisible column, required
            builder.HasData(
                new Website
                {
                    Id = 1,
                    Name = "Ah Fashion",
                    Domain = "http://ah-fashion.runasp.net/",
                    CompanyName = "Ah Fashion",
                    Now = DateTime.UtcNow,
                    IsVisible = true
                }
            );

        }
    }
}
