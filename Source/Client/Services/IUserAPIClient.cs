using NuGet.Protocol.Plugins;
using PostOffice.API.DTOs.User;

namespace PostOffice.Client.Services
{
    public interface IUserAPIClient
    {
        Task<string> Authenticate(UserLoginDTO userLoginDTO);



    }
}
