using ShareEdu.Factory.PL.ViewModels.Settings;

namespace ShareEdu.Factory.PL.Services.NavbarSettings
{
    public interface INavigationService
    {
        Task<List<NavbarLinkViewModel>> GetNavbarLinksAsync();

    }
}
