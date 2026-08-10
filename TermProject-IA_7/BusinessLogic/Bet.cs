namespace TermProject_IA_7.BusinessLogic;

public class Bet
{
    private double _currentBet;
    public double CurrentBet
    {
        get => _currentBet;
        set => _currentBet = value;
    }
    public Bet(double initialBet = 0.0)
    {
        _currentBet = initialBet;
    }
    public void WinBet(ref int coinBalance)
    {
        coinBalance += (int)_currentBet;
    }
    public void LoseBet(ref int coinBalance)
    {
        coinBalance -= (int)_currentBet;
        if (coinBalance < 0) coinBalance = 0;
    }
}