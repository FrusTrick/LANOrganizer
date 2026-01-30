namespace LANOrganizer.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string Title { get; set; }
        public List<UserGames> Owners { get; set; }
    }
}
