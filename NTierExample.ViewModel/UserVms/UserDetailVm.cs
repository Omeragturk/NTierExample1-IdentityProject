namespace NTierExample.ViewModel.UserVms
{
    public class UserDetailVm
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public List<string> RoleNames { get; set; }

        public UserDetailVm()
        {
            RoleNames = new List<string>();
        }
    }
}
