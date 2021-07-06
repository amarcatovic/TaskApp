using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Tasks.Data.UserService;
using TaskApp.Tasks.Utilities.Constants;

namespace TaskApp.Tasks.Utilities.RestClients
{
    public class UsersRestClient
    {
        public async Task<UserReadDto> GetUserById(int userId)
        {
            var client = new RestClient(ApiConstants.USERS_API_URL);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; // Ignore SSL error
            var request = new RestRequest("api/users/" + userId, DataFormat.Json);

            return await client.GetAsync<UserReadDto>(request);
        }
    }
}
