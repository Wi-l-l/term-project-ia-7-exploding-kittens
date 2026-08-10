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
    private GameHistory _gameHistory = new GameHistory();
    private string baseLibrary = "/Users/willock";
    private int _userCardHandCount;
    
    public GameManager()
    {
        //
        LoadGameSettings();
        _cardDeck = new CardDeck(settings.deckSize);
        _difficultyLevel = settings.difficultyLevels;
        
        //load players from the json file
        LoadPlayers();
        foreach (PlayerInfo playerinfo in _storeGamePlayers.PlayerList)
        {
            Player player = new Player(playerinfo.PlayerId, playerinfo.PlayerName, playerinfo.CoinBalance);
            _playersList.Add(player);
        }

        //
        _playerCount = _playersList.Count;
        
        //
        NewGame();
    }

    public ObservableCollection<Player> PlayersList
    {
        get { return _playersList; }
    }
    
    public int UserCardHandCount
    {
        get { return _userCardHandCount; }
    }

    public string TurnStatus
    {
        get
        {
            if (_roundIsOver)
            {
                return "Round is over";
            }
            else
            {
                return "Round can continue";
            }
        }
    }
    
    public Card DrawCard(int playerIndex)
    {
        //Get 1 card from the deck
        Card cardTaken = _cardDeck.ProvideCard();
        
        //check if the card's type is Exploding Kitten
        if (cardTaken.Type == CardType.ExplodingKitten)
        {
            if (!PlayerHasDefuse(playerIndex))
            //tell the player who drew the exploding kitten that they're out
            {
                _playersList[playerIndex].IsEliminated = true;
                _roundIsOver = true;
            
                //check if there is only one player
                int remainingPlayerCount = 0;
                foreach (Player player in _playersList)
                {
                    if (player.IsEliminated == false)
                    {
                        //get card count in hand
                        _userCardHandCount = player.Hand.Count;
                        
                        //Add 1 player to remaining player count
                        remainingPlayerCount++;
                        
                        //Add 1 win to the winning player
                        player.WinCounter++;
                        
                        //Each remaining player will gain 1 score
                        GameResult result = _gameHistory.Results.Last();
                        foreach (GamePlayer gamePlayer in result.Players)
                        {
                            if (gamePlayer.PlayerId == player.Id)
                            {
                                gamePlayer.PlayerScore++;
                            }
                        }
                    }
                }

                if (remainingPlayerCount == 1)
                {
                    _gameIsOver = true;
                }
            }
            
            //stop the game
            
            
            //call GameOver and RewardWinner
            
            //Extending: provide 2 options to go to main menu or to restart
        }
        
        //give the card to the Player
        _playersList[playerIndex].TakeCard(cardTaken);
        return cardTaken;
    }

    public bool PlayerHasExploded()
    {
        return _roundIsOver;
    }
    
    public string DealCards()
    {
        string cardInfo = "";
        for (int playerNo = 0; playerNo < _playerCount; playerNo++)
        {
            if (PlayerIsEliminated(playerNo) == false)
            {
                Card cardDrawn = DrawCard(playerNo);
                cardInfo += _playersList[playerNo].Name + " draw a " + cardDrawn.Type.ToString()+"\n\r";
            }
        }

        return cardInfo;
    }

    public bool PlayerHasDefuse(int playerIndex)
    {
        bool useDefuseCard = false;
        foreach (Card cardInHand in _playersList[playerIndex].Hand)
        {
            if (cardInHand.Type == CardType.DefuseCard)
            {
                useDefuseCard = true;
                cardInHand.Type = CardType.SleepyKitten; //switch defuse card to default SleepyKitten
                _cardDeck.ShuffleDeck();
            }
        }
        return useDefuseCard;
    }

    public void UseDefuseCard()
    {
        
    }

    
    
    public bool GameIsOver()
    {
        SaveGameResults();
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
        
        //initialize a new game record
        LoadGameResults();
        GameResult newGameResult = new GameResult();
        newGameResult.GameId = 1; //TODO?: revisit later
        //add players
        newGameResult.Players = [];
        foreach (Player player in _playersList)
        {
            GamePlayer gamePlayer = new GamePlayer();
            gamePlayer.PlayerId = player.Id;
            gamePlayer.PlayerScore = 0;
            newGameResult.Players.Add(gamePlayer);
        }
        _gameHistory.Results.Add(newGameResult);

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

    public void SaveGameResults()
    {
        
        string path = Path.Combine(FileSystem.AppDataDirectory, "GameHistory.json");
        
        string updatedJson = JsonSerializer.Serialize(_gameHistory);

        File.WriteAllText(path, updatedJson);
    }
    
    public void LoadGameResults()
    {
        
        string path = Path.Combine(FileSystem.AppDataDirectory, "GameHistory.json");
        
        string JsonContent = File.ReadAllText(path);
        
        _gameHistory = JsonSerializer.Deserialize<GameHistory>(JsonContent)!;
    }
}