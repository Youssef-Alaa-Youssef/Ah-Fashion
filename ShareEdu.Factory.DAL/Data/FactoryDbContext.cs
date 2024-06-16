using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Auth;
using System.Reflection;

namespace ShareEdu.Factory.DAL.Data
{
    public class FactoryDbContext : IdentityDbContext<IdentityUser, ApplicationRoles,string>
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
