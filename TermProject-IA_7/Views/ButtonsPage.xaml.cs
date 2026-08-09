using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermProject_IA_7.BusinessLogic;

namespace TermProject_IA_7.Views;

public partial class ButtonsPage : ContentPage
{
    private GameManager _gameManager = new GameManager();
    private int currentPlayerIndex = -1;
    private int playerCount;
    
    public ButtonsPage()
    {
        InitializeComponent();
        playerCount = _gameManager.PlayerCount();
        //_gameManager.NewGame();
    }

    private void OnResetRound(object? sender, EventArgs e)
    {
        //example for shuffling and resetting cardDeck
        _gameManager.ResetRound();
        
    }

    private async void OnDrawCard(object? sender, EventArgs e)
    {

        if (_gameManager.RoundIsOver() || _gameManager.GameIsOver())
        {
            if (_gameManager.RoundIsOver())
            {
                await DisplayAlertAsync("Round Over", "The round must reset", "OK");
            }
            else
            {
                await DisplayAlertAsync("Game Over", "The game must reset", "OK");
            }
        }
        else
        {
            //determine the current player drawing the card
            currentPlayerIndex++;
            if (currentPlayerIndex >= playerCount)
            {
                currentPlayerIndex = 0;
            }

            if (_gameManager.PlayerIsEliminated(currentPlayerIndex) == false)
            {
                Card _cardReceived = _gameManager.DrawCard(currentPlayerIndex);
                    
                //
                await DisplayAlertAsync("Drew card", $"Player {currentPlayerIndex} drew a {_cardReceived.Type.ToString()} card", "OK");
            }
            else
            {
                await DisplayAlertAsync("Player eliminated", $"Player {currentPlayerIndex} is eliminated", "OK");
            }
            
            //
            
        }
        
        

    }

    private void OnNewGame(object? sender, EventArgs e)
    {
        //
        _gameManager.NewGame();
    }

    private void OnSaveGame(object? sender, EventArgs e)
    {
        //
        _gameManager.SaveGameResults();
    }
}