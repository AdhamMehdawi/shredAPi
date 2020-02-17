using Shared.Core.Interfaces;
using Shared.Services.ViewModels.ServicesViewModel;
using Shared.Services.ViewModels.Users;

namespace Shared.Services.UsersServices
{
    public class UserAuthService
    {
        public UserService UserService { get; }
        public IUnitOfWork UnitOfWork { get; }

        public UserAuthService(UserService userService, IUnitOfWork unitOfWork)
        {
            UserService = userService;
            UnitOfWork = unitOfWork;
        }

        public bool ResetPassword(ResetPasswordViewModel passwordViewModel)
        {
            //var user = UnitOfWork.UserRepository.Find(c => c.Id == UserService.Id).FirstOrDefault();

            //if (user == null)
            //{
            //    return false;
            //}

            //var encOldPassword = Encryption.Encrypt(passwordViewModel.OldPassword, true);

            //if (encOldPassword != user.Password)
            //{
            //    return false;
            //}

            //user.Password = Encryption.Encrypt(passwordViewModel.NewPassword, true);
            //user.NeedResetPassword = false;

            //UnitOfWork.UserRepository.Update(user);

            return true;
        }

        public bool RestorePassword(RestorePasswordViewModel passwordViewModel)
        {
            //if (passwordViewModel.Password != passwordViewModel.ConfirmPassword)
            //{
            //    return false;
            //}

            //var user = UnitOfWork.UserRepository
            //    .Find(c => c.ResetToken == passwordViewModel.Token && c.ResetTokenExDate > DateTime.Now)
            //    .FirstOrDefault();

            //if (user == null)
            //{
            //    return false;
            //}

            //user.Password = Encryption.Encrypt(passwordViewModel.Password, true);
            //user.ResetTokenExDate = DateTime.Now.AddMinutes(-1);

            //UnitOfWork.UserRepository.Update(user);

            return true;
        }
    }
}
