using LANOrganizer.Models;

namespace LANOrganizer.Data.Services
{
    public interface ISteamUserResponseService
    {
        Task<List<SteamUserResponse>> GetUserAsync(string steamId);
    }
}
