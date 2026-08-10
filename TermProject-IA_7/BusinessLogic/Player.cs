namespace TermProject_IA_7.BusinessLogic;

public class Player
{
    private int _id;
    private string _name;
    private int _coinBalance;
    private List<Card> _hand = new List<Card>();
    private bool _hasBet;
    private double _bet;
    private bool _isEliminated = false;
    private int _winCounter = 0;
 
    public Player(int id, string name, int coinBalance)
    {
        _id = id;
        _name = name;
        _coinBalance = coinBalance;
    }
 
    public int Id => _id;
    public string Name => _name;
 
    public int CoinBalance
    {
        get => _coinBalance;
        set => _coinBalance = value;
    }
 
    public List<Card> Hand => _hand;
 
    public bool HasBet
    {
        get => _hasBet;
        set => _hasBet = value;
    }
 
    public double BetAmount
    {
        get => _bet;
        set => _bet = value;
    }
 
    public bool IsEliminated
    {
        get => _isEliminated;
        set => _isEliminated = value;
    }

    public int WinCounter
    {
        get { return _winCounter; }
        set { _winCounter = value; } 
    }

    public void AddCard(Card card)
    {
        _hand.Add(card);
    }
 
    public void TakeCard(Card card)
    {
        AddCard(card);
    }
 
    public int CalculateScore()
    {
        return _hand.Count;
    }
}