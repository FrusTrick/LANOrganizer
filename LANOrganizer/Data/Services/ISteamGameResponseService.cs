using LANOrganizer.Models;

namespace LANOrganizer.Data.Services
{
    public interface ISteamGameResponseService
    {
        Task<List<SteamGameResponse>> GetGamesForUserAsync(string steamId);
    }
}
