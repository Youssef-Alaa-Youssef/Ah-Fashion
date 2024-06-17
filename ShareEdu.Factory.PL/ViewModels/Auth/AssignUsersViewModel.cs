namespace ShareEdu.Factory.PL.ViewModels.Auth
{
    public class AssignUsersViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<string> SelectedUsers { get; set; }
    }
}
