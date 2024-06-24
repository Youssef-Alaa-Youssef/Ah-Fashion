﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareEdu.Factory.DAL.Data;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    [DbContext(typeof(FactoryDbContext))]
    [Migration("20240624182413_Add and Aler Model Sections and Content")]
    partial class AddandAlerModelSectionsandContent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Auth.ApplicationRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.DynamicInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InputTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("InputTypeId");

                    b.HasIndex("JobCategoryId");

                    b.HasIndex("JobId");

                    b.ToTable("DynamicInputs", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.InputType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("InputType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsVisible = false,
                            Name = "Text"
                        },
                        new
                        {
                            Id = 2,
                            IsVisible = false,
                            Name = "TextArea"
                        },
                        new
                        {
                            Id = 3,
                            IsVisible = false,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 4,
                            IsVisible = false,
                            Name = "Number"
                        },
                        new
                        {
                            Id = 5,
                            IsVisible = false,
                            Name = "Checkbox"
                        },
                        new
                        {
                            Id = 6,
                            IsVisible = false,
                            Name = "Date"
                        },
                        new
                        {
                            Id = 7,
                            IsVisible = false,
                            Name = "Radio Button"
                        });
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CategoryName");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddTime = new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(8980),
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = 2,
                            AddTime = new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(8998),
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 3,
                            AddTime = new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(9001),
                            Name = "Finance"
                        });
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.Jobs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("JobId");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("AddTime");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastDateToApply")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Jobs", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DynamicInputId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DynamicInputId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Products.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Expire")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SizeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SizeID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Products.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Products for Men",
                            ImagePath = "",
                            NameAr = "رجالي",
                            NameEn = "Men"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Products for Women",
                            ImagePath = "",
                            NameAr = "نسائي",
                            NameEn = "Women"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Products for Kids",
                            ImagePath = "",
                            NameAr = "أطفال",
                            NameEn = "Kids"
                        });
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Products.Size", b =>
                {
                    b.Property<int>("SizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SizeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeID"));

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("SizeID");

                    b.ToTable("Sizes", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Settings.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("SettingGroupId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("Visable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SettingGroupId");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Settings.SettingGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkNameAr")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LinkNameEn")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Visable")
                        .HasColumnType("bit");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ranking")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SettingGroups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Index",
                            Controller = "Home",
                            CreatedAt = new DateTime(2024, 6, 24, 21, 24, 11, 328, DateTimeKind.Local).AddTicks(2769),
                            LinkNameAr = "العامة",
                            LinkNameEn = "General",
                            Name = "General Settings",
                            Permission = "Admin",
                            Visable = true,
                            place = "1",
                            ranking = "1"
                        },
                        new
                        {
                            Id = 2,
                            Action = "AboutUs",
                            Controller = "Home",
                            CreatedAt = new DateTime(2024, 6, 24, 21, 24, 11, 328, DateTimeKind.Local).AddTicks(2844),
                            LinkNameAr = "نبذا عنا",
                            LinkNameEn = "About Us",
                            Name = "About Settings",
                            Permission = "User",
                            Visable = true,
                            place = "2",
                            ranking = "2"
                        });
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Settings.Website", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Domain");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnName("IsVisible");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("Now")
                        .HasColumnType("datetime2")
                        .HasColumnName("Now");

                    b.HasKey("Id");

                    b.ToTable("Websites", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Ah Fashion",
                            Domain = "http://ah-fashion.runasp.net/",
                            IsVisible = true,
                            Name = "Ah Fashion",
                            Now = new DateTime(2024, 6, 24, 18, 24, 11, 330, DateTimeKind.Utc).AddTicks(5142)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Auth.ApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Auth.ApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.DynamicInput", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Employment.InputType", "InputType")
                        .WithMany("DynamicInputs")
                        .HasForeignKey("InputTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShareEdu.Factory.DAL.Models.Employment.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ShareEdu.Factory.DAL.Models.Employment.Jobs", "Job")
                        .WithMany("DynamicInputs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("InputType");

                    b.Navigation("Job");

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.Jobs", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Employment.JobCategory", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.Option", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Employment.DynamicInput", "DynamicInput")
                        .WithMany("Options")
                        .HasForeignKey("DynamicInputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DynamicInput");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Products.Product", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Products.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShareEdu.Factory.DAL.Models.Products.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Settings.Section", b =>
                {
                    b.HasOne("ShareEdu.Factory.DAL.Models.Settings.SettingGroup", "SettingGroup")
                        .WithMany("Sections")
                        .HasForeignKey("SettingGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingGroup");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.DynamicInput", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.InputType", b =>
                {
                    b.Navigation("DynamicInputs");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.JobCategory", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Employment.Jobs", b =>
                {
                    b.Navigation("DynamicInputs");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Products.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShareEdu.Factory.DAL.Models.Settings.SettingGroup", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}