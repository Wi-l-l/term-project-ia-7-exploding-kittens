using System.Collections.ObjectModel;
using System.Text.Json;
using TermProject_IA_7.GameData;

namespace TermProject_IA_7.BusinessLogic;

public class GameManager
{
    private ObservableCollection<Player> _playersList = new ObservableCollection<Player>();
    private int _playerCount;
    private CardDeck _cardDeck; //TODO?: Deck size is unknown
    private bool _gameIsOver = false;
    private bool _roundIsOver = false;
    private int _difficultyLevel;
    
    public GameManager()
    {
        //
        LoadGameSettings();
        _cardDeck = new CardDeck(settings.deckSize);
        //_playerCount = settings.maxUsers;
        _difficultyLevel = settings.difficultyLevels;
        
        //for (int currPlayer = 0; currPlayer < _playerCount; currPlayer++)
        //{
        //    Player player = new Player();
        //    _playersList.Add(player);
        //}
        
        //load players from the json file
        LoadPlayers();
        foreach (PlayerInfo playerinfo in _storeGamePlayers.PlayerList)
        {
            Player player = new Player(playerinfo.PlayerId, playerinfo.PlayerName, playerinfo.CoinBalance);
            _playersList.Add(player);
        }

        _playerCount = _playersList.Count;
    }

    public Card DrawCard(int playerIndex)
    {
        //Get 1 card from the deck
        Card cardTaken = _cardDeck.ProvideCard();
        
        //check if the card's type is Exploding Kitten

        if (cardTaken.Type == CardType.ExplodingKitten)
        {
            //tell the player who drew the exploding kitten that they're out
            _playersList[playerIndex].IsEliminated = true;
            _roundIsOver = true;
            
            //check if there is only one player
            int remainingPlayerCount = 0;
            foreach (Player player in _playersList)
            {
                if (player.IsEliminated == false)
                {
                    remainingPlayerCount++;
                }
            }

            if (remainingPlayerCount == 1)
            {
                _gameIsOver = true;
            }
            
            //stop the game

            //call GameOver and RewardWinner

            //Extending: provide 2 options to go to main menu or to restart
        }
        
        //give the card to the Player
        _playersList[playerIndex].TakeCard(cardTaken);
        return cardTaken;
    }
    
    public bool GameIsOver()
    {
        return _gameIsOver;
    }

    public bool RoundIsOver()
    {
        return _roundIsOver;
    }

    public int PlayerCount()
    {
        return _playerCount;
    }
    
    public bool PlayerIsEliminated(int playerIndex)
    {
        return _playersList[playerIndex].IsEliminated;
    }

    public int GetDifficultyLevel()
    {
        return _difficultyLevel;
    }
    
    public void RewardWinner()
    {
        //
    }

    public void ResetRound()
    {
        _cardDeck.ResetDeck();
        _roundIsOver = false;
    }

    public void NewGame()
    {
        ResetRound();
        foreach (Player player in _playersList)
        {
            player.IsEliminated = false;
        }

        _gameIsOver = false;
    }

    private GameSettings settings;
    public void LoadGameSettings()
    {
        string path = Path.Combine(
            AppContext.BaseDirectory,
            "../Resources/GameData/GameSettings.json");
        string JsonContent = File.ReadAllText(path);

        settings = JsonSerializer.Deserialize<GameSettings>(JsonContent)!;
        
    }

    private StoreGamePlayers _storeGamePlayers;
    public void LoadPlayers()
    {
        string path = Path.Combine(
            AppContext.BaseDirectory,
            "../Resources/GameData/Players.json");
        string JsonContent = File.ReadAllText(path);
        
        _storeGamePlayers = JsonSerializer.Deserialize<StoreGamePlayers>(JsonContent)!;
    }
}