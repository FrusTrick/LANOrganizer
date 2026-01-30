namespace LANOrganizer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string SteamId { get; set; }
        public string ProfileName { get; set; }
        public List<UserGames> Games { get; set; }
    }
}
