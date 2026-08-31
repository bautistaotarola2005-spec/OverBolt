using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClashManager.ViewModels;

public partial class InicioViewModel : ViewModelBase, IDisposable
{
    private static readonly DateTime ProximoClash = new(2026, 9, 19, 17, 0, 0);

    private readonly DispatcherTimer _temporizador;

    public string NotasParche =>
        "Parche 14.18 — nerfs a Swain (menos daño base) y Galio (más CD en el R); buff a Lee Sin (más velocidad tras Q).";

    [ObservableProperty]
    public partial string TiempoRestante { get; set; }

    public InicioViewModel()
    {
        TiempoRestante = CalcularTiempoRestante();

        _temporizador = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _temporizador.Tick += (_, _) => TiempoRestante = CalcularTiempoRestante();
        _temporizador.Start();
    }

    private static string CalcularTiempoRestante()
    {
        var restante = ProximoClash - DateTime.Now;

        if (restante <= TimeSpan.Zero)
            return "¡El Clash ya empezó!";

        return $"{restante.Days} días, {restante.Hours} h, {restante.Minutes} min, {restante.Seconds} s";
    }

    public void Dispose() => _temporizador.Stop();
}
