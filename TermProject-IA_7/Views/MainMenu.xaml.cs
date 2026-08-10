namespace TermProject_IA_7.Views;

using BusinessLogic;
using GameData;
 
public partial class MainMenu : ContentPage

{

    private StoreGamePlayers _playersData;
 
    public MainMenu()

    {

        InitializeComponent();

        LoadUserData();

    }
 
    private void LoadUserData()

    {

        _playersData = DataLoader.LoadPlayers();

        if (_playersData.PlayerList.Count > 0)

        {

            var activePlayer = _playersData.PlayerList[0];

            lblProfile.Text = $"Profile: {activePlayer.PlayerName}";

            lblCoins.Text = $"Coins: {activePlayer.CoinBalance}";

        }

    }
 
    private async void OnStartGame(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync(nameof(GameScreen));

    }
 
    private async void OnViewStats(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync("//StatsScreen");

    }

}