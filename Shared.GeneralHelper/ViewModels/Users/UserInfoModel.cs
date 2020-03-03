namespace Shared.GeneralHelper.ViewModels.Users
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string IpAddress { get; set; }
        public string AcceptToken { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
    }
}
