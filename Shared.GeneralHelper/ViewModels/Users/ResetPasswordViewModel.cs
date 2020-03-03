 

namespace Shared.GeneralHelper.ViewModels.Users
{
    public class ResetPasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class RestorePasswordViewModel
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
