using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OverBolt.ViewModels;

public partial class InicioViewModel : ViewModelBase, IDisposable
{
    private static readonly DateTime ProximoTorneo = new(2026, 9, 19, 17, 0, 0);

    private readonly DispatcherTimer _temporizador;

    public string NotasParche =>
        "Temporada 18 — nerf a Sojourn (menos daño de railgun) y a Orisa (más enfriamiento en Fortificar); " +
        "buff a Ana (la granada biótica gana alcance).";

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
        var restante = ProximoTorneo - DateTime.Now;

        if (restante <= TimeSpan.Zero)
            return "¡El torneo ya empezó!";

        return $"{restante.Days} días, {restante.Hours} h, {restante.Minutes} min, {restante.Seconds} s";
    }

    public void Dispose() => _temporizador.Stop();
}
