using System.Threading.Tasks;
using RestSharp;
using TaskApp.Users.Data.PhotosService;
using TaskApp.Users.Utilities.Contants;

namespace TaskApp.Users.Utilities.RestClients
{
    public class PhotosRestClient
    {
        public async Task<PhotoReturnDto> GetPhotoByUserId(int userId)
        {
            var client = new RestClient(ApiConstants.PHOTOS_API_URL);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; // Ignore SSL error
            var request = new RestRequest("api/photos/" + userId, DataFormat.Json);

            return await client.GetAsync<PhotoReturnDto>(request);
        }
    }
}
