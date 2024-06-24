using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareEdu.Factory.DAL.Models.Settings;

namespace ShareEdu.Factory.DAL.Data.Configurations
{
    public class SettingGroupConfiguration : IEntityTypeConfiguration<SettingGroup>
    {
        public void Configure(EntityTypeBuilder<SettingGroup> builder)
        {
            builder.ToTable("SettingGroups"); // Set table name if different

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
            builder.Property(sg => sg.Permission).HasMaxLength(100);

            // Seed initial data if needed
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
                    Permission = "Admin",
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
                    Permission = "User",
                }
            );
        }
    }
}
