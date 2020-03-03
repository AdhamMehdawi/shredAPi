using Shared.Core.HelperModels;

namespace Shared.GeneralHelper.ViewModels.Users
{
    public class AppUserViewModel:BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsSuperAdmin { get; set; }
     }

    public class  DisplayUserViewModel : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
         public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}