using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClashManager.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly InicioViewModel _inicioViewModel = new();
    private readonly RosterViewModel _rosterViewModel = new();
    private readonly CampeonesViewModel _campeonesViewModel = new();
    private readonly PartidasViewModel _partidasViewModel = new();

    [ObservableProperty]
    public partial ViewModelBase VistaActual { get; set; }

    public event Action? CerrarSesion;

    public MainViewModel()
    {
        VistaActual = _inicioViewModel;
    }

    [RelayCommand]
    private void IrAInicio() => VistaActual = _inicioViewModel;

    [RelayCommand]
    private void IrARoster() => VistaActual = _rosterViewModel;

    [RelayCommand]
    private void IrACampeones() => VistaActual = _campeonesViewModel;

    [RelayCommand]
    private void IrAPartidas() => VistaActual = _partidasViewModel;

    [RelayCommand]
    private void Salir()
    {
        _inicioViewModel.Dispose();
        CerrarSesion?.Invoke();
    }
}
