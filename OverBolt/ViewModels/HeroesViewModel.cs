using System.Collections.Generic;
using System.Linq;
using OverBolt.Models;
using OverBolt.Services;

namespace OverBolt.ViewModels;

public class HeroesViewModel : ViewModelBase
{
    private const int PorRol = 2;

    /// <summary>Los héroes agrupados por el jugador que los juega.</summary>
    public List<GrupoHeroes> Grupos { get; }

    /// <summary>Las dos composiciones meta más la sugerida a partir del pool del equipo.</summary>
    public List<ComposicionEquipo> Composiciones { get; }

    public HeroesViewModel()
    {
        Grupos = DatosDemo.Jugadores
            .Select(j => new GrupoHeroes
            {
                BattleTag = j.BattleTag,
                Rol = j.Rol,
                Pool = DatosDemo.PoolPorJugador.TryGetValue(j.BattleTag, out var pool)
                    ? pool
                    : new List<HeroeDeJugador>(),
            })
            .ToList();

        var claves = DatosDemo.PoolPorJugador.Values
            .SelectMany(p => p)
            .Select(h => h.Heroe.Clave)
            .ToHashSet();

        foreach (var meta in DatosDemo.ComposicionesMeta)
        {
            int cubiertos = meta.Todos.Count(h => claves.Contains(h.Clave));
            meta.Afinidad = $"{cubiertos} de 6 héroes en el pool del equipo";
        }

        Composiciones = new List<ComposicionEquipo>(DatosDemo.ComposicionesMeta) { Sugerida() };
    }

    /// <summary>Arma una composición con los héroes de mayor nivel del equipo en cada rol.</summary>
    private static ComposicionEquipo Sugerida()
    {
        var tanques = MejoresDe(Rol.Tanque);
        var danos = MejoresDe(Rol.Daño);
        var soportes = MejoresDe(Rol.Soporte);

        var elegidos = tanques.Concat(danos).Concat(soportes).ToList();
        int promedio = elegidos.Count == 0 ? 0 : (int)elegidos.Average(h => h.Nivel);

        return new ComposicionEquipo
        {
            Nombre = "Sugerida",
            Tipo = "Por cercanía",
            Descripcion = "Armada con los héroes de mayor nivel del equipo en cada rol, no con el meta.",
            Tanques = tanques.Select(h => h.Heroe).ToList(),
            Danos = danos.Select(h => h.Heroe).ToList(),
            Soportes = soportes.Select(h => h.Heroe).ToList(),
            Afinidad = $"nivel promedio {promedio}",
        };
    }

    private static List<HeroeDeJugador> MejoresDe(Rol rol) =>
        DatosDemo.PoolPorJugador.Values
            .SelectMany(p => p)
            .Where(h => h.Rol == rol)
            .OrderByDescending(h => h.Nivel)
            .Take(PorRol)
            .ToList();
}
