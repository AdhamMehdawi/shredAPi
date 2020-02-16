 

namespace Shared.Services.ViewModels.Jwt
{
    public class TokenWrapper
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public double ExpiresIn { get; set; }
    }
}
