using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameplayKit;
using TermProject_IA_7.BusinessLogic;

namespace TermProject_IA_7.Views;

public partial class StatisticsScreen : ContentPage
{
    private GameManager _currentManager = GameScreen.GameManager;
    
    public StatisticsScreen()
    {
        InitializeComponent();
        try
        {
            foreach (Player player in _currentManager.PlayersList)
            {
                _txtPlayerStats.Text += $"Player: {player.Name} \n Wins: {player.WinCounter} \n\r";
            }
        }
        catch (Exception e)
        {
            return;
        }
        
    }
    
    
}