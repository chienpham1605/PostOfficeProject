using Newtonsoft.Json;
using PostOffice.API.DTOs.User;
using PostOffice_Server.Models;
using System.Text;

namespace PostOffice.Client.Services
{
    public class UserAPIClient : IUserAPIClient
    {
        private readonly HttpClient _httpClient;

        public UserAPIClient(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = APIs.baseAddress;
        }

        public async Task<string> Authenticate(UserLoginDTO userLoginDTO)
        {
            string data = JsonConvert.SerializeObject(userLoginDTO);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress
                + APIs.loginAPI, content).Result;
            string token =await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
