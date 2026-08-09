namespace TermProject_IA_7.GameData;

public class GameResult
{
    public int GameId { get; set; }
    public List<GamePlayer> Players { get; set; }
}

public class GamePlayer
{
    public int PlayerId { get; set; }
    public int PlayerScore { get; set; }
}

public class GameHistory
{
    public List<GameResult> Results { get; set; } = new List<GameResult>();
}