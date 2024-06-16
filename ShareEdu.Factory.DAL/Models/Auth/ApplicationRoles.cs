using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareEdu.Factory.DAL.Models.Auth
{
    public class ApplicationRoles :IdentityRole
    {
        public  String RoleNameAr { get; set; } = string.Empty;
    }
}
