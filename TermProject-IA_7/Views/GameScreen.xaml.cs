using TermProject_IA_7.BusinessLogic;

namespace TermProject_IA_7;

public partial class GameScreen : ContentPage 
{

    private GameManager _gameManager;
    
    public GameScreen()
    {
        InitializeComponent();
        _gameManager = new GameManager();
        InitializeRound();
    }
    
    private void InitializeRound()
    {
        _txtGameLog.Text += "\n[18:17] Round Initialized.";
        UpdateDisplay();
    }
    
    // Triggered when the "Draw Card" button is clicked
    private async void OnDealCards(object sender, EventArgs e)
    {
        try 
        {
            // Draw logic handles drawing cards and checks for exploding kittens
            _gameManager.DealCards();
            _txtGameLog.Text += "\n[18:18] Player drew a card.";
            UpdateDisplay();
            
            // Exploding Kitten checks
            if (_gameManager.PlayerHasExploded())
            {
                await OnExplodingKitten();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Action Error", ex.Message, "OK");
        }
    }
    
    // Triggered when a player taps an action card inside their Hand framework
    private async void OnPlayCards(object sender, EventArgs e)
    {
        try
        {
            //Button btnCard = sender as Button;
            //string cardType = btnCard.Text;
            
            //_gameManager.PlayCard(cardType); // Process gameplay rules
            //_txtGameLog.Text += $"\n[18:19] Played card: {cardType}";
            
            //_lblLastDiscardedCard.Text = cardType;
            //UpdateDisplay();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Play Error", ex.Message, "OK");
        }
    }


    // Evaluates loss state if an Exploding Kitten card is drawn without Defuse
    private async Task OnExplodingKitten()
    {
        _txtGameLog.Text += "\n[18:20] EXPLODING KITTEN DRAWN!";
        bool hasDefuse = _gameManager.PlayerHasDefuse();
        
        if (!hasDefuse)
        {

            DisplayGameOver();

            await DisplayAlert("Boom!", "You drew an Exploding Kitten and had no Defuse card!", "OK");

            await Navigation.PopAsync(); // Return back to menu
        }

        else
        {
            _gameManager.UseDefuseCard();
            _txtGameLog.Text += "\n[18:20] Player used DEFUSE.";
            UpdateDisplay();
            await DisplayAlert("Saved!", "You defused the kitten!", "OK");
        }
    }
    
    private void DisplayGameOver()
    {
        _lblGameStatus.Text = "Status: GAME OVER";
    }


    private void UpdateDisplay()
    {
        // Sync current counts with back-end models
        _lblComputerHandSize.Text = $"Hand Size: {_gameManager.UserCardHandCount} Cards";
        _lblGameStatus.Text = $"Status: {_gameManager.TurnStatus}";
        
        // Hand layouts would be dynamically loaded in production from player.Hand collection
        
    }

}