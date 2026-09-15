using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OverBolt.Services;

namespace OverBolt.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string NombreUsuario { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Contrasena { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string MensajeError { get; set; } = string.Empty;

    public event Action? LoginExitoso;

    [RelayCommand]
    private void Ingresar()
    {
        bool credencialesValidas = DatosDemo.Usuarios.Exists(u =>
            u.NombreUsuario == NombreUsuario && u.Contrasena == Contrasena);

        if (credencialesValidas)
        {
            MensajeError = string.Empty;
            LoginExitoso?.Invoke();
        }
        else
        {
            MensajeError = "Usuario o contraseña incorrectos.";
        }
    }
}