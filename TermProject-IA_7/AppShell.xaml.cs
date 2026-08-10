using TermProject_IA_7.Views;

namespace TermProject_IA_7;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(StatisticsScreen), typeof(StatisticsScreen));
        Routing.RegisterRoute(nameof(GameScreen), typeof(GameScreen));
    }
}