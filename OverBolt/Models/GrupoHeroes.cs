using System.Collections.Generic;
using System.Linq;

namespace OverBolt.Models;

public class GrupoHeroes
{
    public const int CuantosMostrar = 3;

    public string BattleTag { get; set; } = string.Empty;
    public Rol Rol { get; set; }
    public List<HeroeDeJugador> Pool { get; set; } = new();

    /// <summary>Los héroes de más nivel del jugador, que son los que se muestran.</summary>
    public List<HeroeDeJugador> Principales =>
        Pool.OrderByDescending(h => h.Nivel).Take(CuantosMostrar).ToList();
}
