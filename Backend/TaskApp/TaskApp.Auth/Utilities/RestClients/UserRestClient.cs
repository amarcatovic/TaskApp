using System.Threading.Tasks;
using TaskApp.Auth.Data.UserService;
using RestSharp;
using TaskApp.Auth.Utilities.Constants;

namespace TaskApp.Auth.Utilities.RestClients
{
    public class UserRestClient
    {
        public async Task<UserReadDto> GetUserByEmailAsync(string email)
        {
            var client = new RestClient(ApiConstants.USERS_API_URL);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; // Ignore SSL error
            var request = new RestRequest("api/users/" + email, DataFormat.Json);

            return await client.GetAsync<UserReadDto>(request);
        }
    }
}
