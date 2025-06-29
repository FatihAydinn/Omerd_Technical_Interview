using Newtonsoft.Json;
using Q6_Token_exp.Models;

namespace Q6_Token_exp.Services
{
    public class TokenService
    {
        private static string _token;
        private static DateTime _tokenExpireTime;

        public async Task<string> GetToken()
        {
            if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpireTime) {
                return _token;
            }

            using var client = new HttpClient();
            var content = new StringContent("grant_type=client_credentials");
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await client.PostAsync("https://xyz.com/api/token", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TokenResponse>(responseBody);

            _token = result.access_token;
            _tokenExpireTime = DateTime.UtcNow.AddSeconds(result.expires_in - 60);

            return _token;
        }
    }
}
