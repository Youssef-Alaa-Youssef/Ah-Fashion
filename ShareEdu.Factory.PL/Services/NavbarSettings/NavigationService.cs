using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Settings;
using ShareEdu.Factory.PL.ViewModels.Settings;
using System.Security.Claims;

namespace ShareEdu.Factory.PL.Services.NavbarSettings
{
    public class NavigationService : INavigationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public NavigationService(IHttpContextAccessor httpContextAccessor ,IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<NavbarLinkViewModel>> GetNavbarLinksAsync()
        {
            var settingGroups = await _unitOfWork.GetRepository<SettingGroup>().GetAllAsync();

            var navbarLinks = settingGroups
                .Where(x => x.Permission == "User" || x.Permission == DetermineUserRole())
                .Where(x => x.Visable)
                .OrderBy(x => x.place)
                .ThenBy(x => x.ranking)
                .Select(x => new NavbarLinkViewModel
                {
                    LinkNameEn = x.LinkNameEn,
                    LinkNameAr = x.LinkNameAr,
                    Action = x.Action,
                    Controller = x.Controller,
                    Place = x.place,
                    Ranking = x.ranking,
                    Visible = x.Visable,
                    Name = x.Name,
                    Permission = x.Permission
                })
                .ToList();

            return navbarLinks;
        }

        private string DetermineUserRole()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var userRoles = httpContext.User.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                if (userRoles.Any())
                {
                    return userRoles.First().ToUpper(); // Assuming you want the first role and normalize it to lowercase
                }
            }

            return "User"; 
        }

    }

}
