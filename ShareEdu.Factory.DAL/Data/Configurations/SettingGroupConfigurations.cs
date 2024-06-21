using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Settings;
using System.Collections.Generic;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    public class SettingGroupConfigurations : IEntityTypeConfiguration<SettingGroup>
    {
        public void Configure(EntityTypeBuilder<SettingGroup> builder)
        {
            builder.ToTable("SettingGroups"); // Optional: Set the table name if different

            // Primary key
            builder.HasKey(sg => sg.Id);

            // Properties
            builder.Property(sg => sg.Id).IsRequired();
            builder.Property(sg => sg.Name).IsRequired().HasMaxLength(255);
            builder.Property(sg => sg.LinkNameEn).HasMaxLength(255);
            builder.Property(sg => sg.LinkNameAr).HasMaxLength(255);
            builder.Property(sg => sg.Controller).HasMaxLength(100);
            builder.Property(sg => sg.Action).HasMaxLength(100);
            builder.Property(sg => sg.Visable).IsRequired();
            builder.Property(sg => sg.ranking).HasMaxLength(50); // Adjust max length as necessary
            builder.Property(sg => sg.place).HasMaxLength(50); // Adjust max length as necessary

            builder.HasData(
                new SettingGroup
                {
                    Id = 1,
                    Name = "General Settings",
                    LinkNameEn = "General",
                    LinkNameAr = "العامة",
                    Controller = "Home",
                    Action = "Index",
                    Visable = true,
                    ranking = "1",
                    place = "1",
    
                },
                new SettingGroup
                {
                    Id = 2,
                    Name = "About Settings",
                    LinkNameEn = "About Us",
                    LinkNameAr = "نبذا عنا",
                    Controller = "Home",
                    Action = "AboutUs",
                    Visable = true,
                    ranking = "2",
                    place = "2",
                }
            );
        }
    }
}
