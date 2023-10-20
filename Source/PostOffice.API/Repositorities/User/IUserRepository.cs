using PostOffice.API.DTOs.User;

namespace PostOffice.API.Repositorities.User
{
    public interface IUserRepository
    {
        Task<string> Authenticate(UserLoginDTO userLogin);
        Task<bool> Register(UserRegisterDTO userRegister);
    }
}
