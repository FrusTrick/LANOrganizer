using LANOrganizer.Data;
using LANOrganizer.Data.Services;

namespace LANOrganizer.Endpoints
{

    public class LanorgEndpoints
    {
        private readonly ISteamGameResponseService _steamGameResponseService;

        public LanorgEndpoints(ISteamGameResponseService steamService)
        {
            _steamGameResponseService = steamService;
        }

        public void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/FetchGames/{id}", async (LanorgDbContext context, string id) =>
            {

                var games = await _steamGameResponseService.GetGamesForUserAsync(id);

                return Results.Ok(games);

            });

        }
    }
}
