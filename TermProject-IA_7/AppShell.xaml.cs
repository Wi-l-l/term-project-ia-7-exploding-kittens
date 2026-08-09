using TermProject_IA_7.Views;

namespace TermProject_IA_7;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ButtonsPage), typeof(ButtonsPage));
    }
}