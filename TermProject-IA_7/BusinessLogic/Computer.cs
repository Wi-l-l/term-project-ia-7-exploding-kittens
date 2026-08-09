namespace TermProject_IA_7.BusinessLogic;
 
public class Computer
{
    private string _difficulty;
 
    public string Difficulty
    {
        get => _difficulty;
        set => _difficulty = value;
    }
 
    public Computer(string difficulty = "Medium")
    {
        _difficulty = difficulty;
    }
 
    public string MakeDecision()
    {
        return _difficulty switch
        {
            "Easy" => "Draw",
            "Medium" => Random.Shared.Next(0, 2) == 0 ? "Draw" : "PlayCard",
            "Hard" => "PlayCard",
            _ => "Draw"
        };
    }
}