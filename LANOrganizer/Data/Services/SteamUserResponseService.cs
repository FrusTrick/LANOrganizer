using LANOrganizer.Models;

namespace LANOrganizer.Data.Services
{
    public class SteamUserResponseService : ISteamUserResponseService
    {
        private readonly HttpClient _httpClient;

        public SteamUserResponseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task <List<SteamUserResponse>> GetUserAsync(string steamId)
        {
            var response = await _httpClient.GetFromJsonAsync<SteamUserResponse>($"IPlayerService/GetOwnedGames/v0001/?key=&include_appinfo=1&steamid={steamId}&format=json");

            if (response != null)
            {
                return new List<SteamUserResponse> { response };
            }
            else
            {
                return new List<SteamUserResponse>();
            }
        }
    }
}
