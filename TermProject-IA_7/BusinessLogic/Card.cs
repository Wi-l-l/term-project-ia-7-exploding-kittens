namespace TermProject_IA_7.BusinessLogic;

public class Card
{
    //private byte _value;
    private CardType _type; 
    
    public Card(CardType type)
    {
        //_value = value;
        _type = type;
    }

    public CardType Type
    {
        get { return _type; }
        set { _type = value; }
    }
}