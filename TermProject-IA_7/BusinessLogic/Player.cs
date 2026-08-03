namespace TermProject_IA_7.BusinessLogic;

public class Player
{
    private int _id;
    private string _name;
    private int _coinBalance;
    private List<Card> _cardsOnHand = new List<Card>();
    private bool _isEliminated = false;
    
    public Player(int id, string name, int coinBalance)
    {
        //
        _id = id;
        _name = name;
        _coinBalance = coinBalance;
    }
    
    public void TakeCard(Card card)
    {
        //
        _cardsOnHand.Add(card);
    }

    public bool IsEliminated
    {
        get { return _isEliminated; }
        set { _isEliminated = value; }
    }
}