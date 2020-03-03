using System.ComponentModel.DataAnnotations;

namespace Shared.GeneralHelper.ViewModels.Jwt
{
    public class CredentialsViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
