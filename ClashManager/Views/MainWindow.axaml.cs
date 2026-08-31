using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ClashManager.ViewModels;

namespace ClashManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var viewModel = new MainViewModel();
        viewModel.CerrarSesion += VolverAlLogin;
        DataContext = viewModel;
    }

    private void VolverAlLogin()
    {
        var loginWindow = new LoginWindow();

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = loginWindow;
        }

        loginWindow.Show();
        Close();
    }
}
