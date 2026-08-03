using System.Collections.ObjectModel;

namespace TermProject_IA_7.BusinessLogic;

public class CardDeck
{
    private Card _card;
    private ObservableCollection<Card> _cardList = new ObservableCollection<Card>();
    private int _deckSize;
    private Random _randomizer;
    
    public CardDeck(int deckSize)
    {
        _deckSize = deckSize;
        
        //
        for (int currCard = 0; currCard < _deckSize; currCard++)
        {
            //create card
            Card card = new Card(CardType.SleepyKitten); //default to SleepyKitten

            //add card to deck
            _cardList.Add(card);
        }
    }
    
    public void ProvideCard()
    {
        //
    }

    public void ResetDeck()
    {
        
    }

    public void ShuffleDeck()
    {
        //
    }
}