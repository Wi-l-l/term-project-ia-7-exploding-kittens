namespace TermProject_IA_7.GameData;

public class PlayerInfo
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int CoinBalance { get; set; }
}

public class StoreGamePlayers
{
    public List<PlayerInfo> PlayerList { get; set; } = new();
}