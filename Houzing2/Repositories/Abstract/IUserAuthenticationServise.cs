using Houzing2.Models.DTO;

namespace Houzing2.Repositories.Abstract
{
    public interface IUserAuthenticationServise
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
        //Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}
