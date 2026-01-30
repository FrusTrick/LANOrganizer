using LANOrganizer.Models;

namespace LANOrganizer.Data.Services
{
    public class SteamGameResponseService : ISteamGameResponseService
    {
        private readonly HttpClient _httpClient;

        public SteamGameResponseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SteamGameResponse>> GetGamesForUserAsync(string steamId)
        {
            var response = await _httpClient.GetFromJsonAsync<SteamGameResponse>("IPlayerService/GetOwnedGames/v0001/?key=E8D10200DD162E21EED901F4C6AD18EB&include_appinfo=1&steamid=76561198013726976&format=json");

            if(response == null)
            {
                return new List<SteamGameResponse>();
            }
            else
            {
                return response.

            }
        }
    }
}
