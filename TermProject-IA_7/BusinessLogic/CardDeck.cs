using System.Collections.ObjectModel;

namespace TermProject_IA_7.BusinessLogic;

public class CardDeck
{
    private Card _card;
    private ObservableCollection<Card> _cardList = new ObservableCollection<Card>();
    private int _deckSize;
    private Random _randomizer = new Random();
    private int lastCardIndex;
    
    public CardDeck(int deckSize)
    {
        _deckSize = deckSize;
        lastCardIndex = _deckSize - 1;
        
        //
        for (int currCard = 0; currCard < _deckSize; currCard++)
        {
            //create card
            Card card = new Card(CardType.SleepyKitten); //default to SleepyKitten

            //add card to deck
            _cardList.Add(card);
        }
        
        ShuffleDeck();
    }
    
    public Card ProvideCard()
    {
        if (lastCardIndex < 0)
        {
            throw new ArgumentException("There are no more cards in the deck");
        }
        
        //take the last card from the cardDeck, index-wise
        Card lastCard = _cardList[lastCardIndex];

        //Set the last card index for the next card to provide
        lastCardIndex--;
        
        //return the card to the player
        return lastCard;
    }

    public void ResetDeck()
    {
        ShuffleDeck();
        lastCardIndex = _deckSize - 1;
    }

    public void ShuffleDeck()
    {
        //pick random element to have it set to an Exploding Kitten card
        int explodingKittenIndex = _randomizer.Next(0, _deckSize);
        _cardList[explodingKittenIndex].Type = CardType.ExplodingKitten;
        
        //set the other cards to be any card type other than an Exploding Kitten card
        int cardIndex = 0;
        
        foreach (Card card in _cardList)
        {
            if (cardIndex != explodingKittenIndex)
            {
                int cardTypeNum = _randomizer.Next(0, 3);
                switch (cardTypeNum)
                {
                    case 0:
                        card.Type = CardType.SleepyKitten;
                        break;
                    case 1:
                        card.Type = CardType.HappyKitten;
                        break;
                    case 2:
                        card.Type = CardType.MysteriousKitten;
                        break;
//                    case 3:
                        //card.Type = CardType.DefuseCard;
                        //break;
                } 
            }
            
            cardIndex++;
        }
    }
}