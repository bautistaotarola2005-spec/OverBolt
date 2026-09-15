using System.Collections.Generic;
using OverBolt.Models;
using OverBolt.Services;

namespace OverBolt.ViewModels;

public class PartidasViewModel : ViewModelBase
{
    public List<Partida> Partidas => DatosDemo.Partidas;

    public int Victorias => Partidas.FindAll(p => p.EsVictoria).Count;
    public int Derrotas => Partidas.Count - Victorias;

    public string Balance => $"{Victorias}V - {Derrotas}D";

    public string Winrate => Partidas.Count == 0
        ? "-"
        : $"{(int)(Victorias * 100.0 / Partidas.Count)}% de victorias";
}
