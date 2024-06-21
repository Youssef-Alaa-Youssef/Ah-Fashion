using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.BLL.Repositories;
using ShareEdu.Factory.BLL;
using ShareEdu.Factory.DAL.Data;
using ShareEdu.Factory.DAL.Models.Auth;
using ShareEdu.Factory.PL.Helper;
using ShareEdu.Factory.PL.Services;
using ShareEdu.Factory.PL.Services.Email;

namespace ShareEdu.Factory.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("MailConfigurations"));
            builder.Services.AddSingleton<EmailConfiguration>();
            builder.Services.AddControllersWithViews();
            builder.Configuration.GetConnectionString("Factory");
            builder.Services.AddDbContext<FactoryDbContext>(options =>
            {
                options.UseLazyLoadingProxies(); 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Factory")); // SQL Server provider
            });


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddIdentity<IdentityUser, ApplicationRoles>(option=> option.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<FactoryDbContext>()
                .AddDefaultTokenProviders();
            //builder.Services.AddAutoMapper();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath= "/Auth/LogOut";
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(2);
            });

            builder.Services.AddScoped<IEmailService, EmailSender>();
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Home/ErrorProd");
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
