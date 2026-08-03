namespace TermProject_IA_7.BusinessLogic;

public class Player
{
    private List<Card> _cardsOnHand = new List<Card>();
    private bool _isEliminated = false;
    
    public Player()
    {
        //
        
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