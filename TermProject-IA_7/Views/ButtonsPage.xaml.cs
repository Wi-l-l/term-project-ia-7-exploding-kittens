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
    
    public ButtonsPage()
    {
        InitializeComponent();
        
    }

    private void OnShuffleCards(object? sender, EventArgs e)
    {
        //
    }
}