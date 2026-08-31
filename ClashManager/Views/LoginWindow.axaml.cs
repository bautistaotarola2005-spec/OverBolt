using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ClashManager.ViewModels;

namespace ClashManager.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();

        var viewModel = new LoginViewModel();
        viewModel.LoginExitoso += AbrirVentanaPrincipal;
        DataContext = viewModel;
    }

    private void AbrirVentanaPrincipal()
    {
        var mainWindow = new MainWindow();

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = mainWindow;
        }

        mainWindow.Show();
        Close();
    }
}
