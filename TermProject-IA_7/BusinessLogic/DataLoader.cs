namespace TermProject_IA_7.BusinessLogic;

using System.Text.Json;
using TermProject_IA_7.GameData;
 
public static class DataLoader
{
    public static GameSettings LoadSettings()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "../Resources/GameData/GameSettings.json");
        if (!File.Exists(path)) return new GameSettings();
        string jsonContent = File.ReadAllText(path);
        return JsonSerializer.Deserialize<GameSettings>(jsonContent) ?? new GameSettings();
    }
 
    public static StoreGamePlayers LoadPlayers()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "../Resources/GameData/Players.json");
        if (!File.Exists(path)) return new StoreGamePlayers();
 
        string jsonContent = File.ReadAllText(path);
        return JsonSerializer.Deserialize<StoreGamePlayers>(jsonContent) ?? new StoreGamePlayers();
    }
 
    public static GameHistory LoadGameHistory()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "../Resources/GameData/GameHistory.json");
        if (!File.Exists(path)) return new GameHistory();
 
        string jsonContent = File.ReadAllText(path);
        return JsonSerializer.Deserialize<GameHistory>(jsonContent) ?? new GameHistory();
    }
}