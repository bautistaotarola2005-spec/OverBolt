using System.Collections.Generic;
using System.Linq;
using ClashManager.Models;

namespace ClashManager.Services;

/// <summary>
/// Catálogo completo de héroes de Overwatch 2 (53 en total; Doctrine queda afuera
/// mientras siga en beta). Las claves coinciden con el nombre de archivo de cada imagen
/// dentro de Assets/heroes/, así que agregar un héroe es sumar una línea acá y su .png.
/// </summary>
public static class CatalogoHeroes
{
    public static List<Heroe> Todos { get; } = new()
    {
        new() { Clave = "ana",           Nombre = "Ana",           Rol = Rol.Soporte },
        new() { Clave = "anran",         Nombre = "Anran",         Rol = Rol.Daño },
        new() { Clave = "ashe",          Nombre = "Ashe",          Rol = Rol.Daño },
        new() { Clave = "baptiste",      Nombre = "Baptiste",      Rol = Rol.Soporte },
        new() { Clave = "bastion",       Nombre = "Bastion",       Rol = Rol.Daño },
        new() { Clave = "brigitte",      Nombre = "Brigitte",      Rol = Rol.Soporte },
        new() { Clave = "cassidy",       Nombre = "Cassidy",       Rol = Rol.Daño },
        new() { Clave = "dmon",          Nombre = "D.Mon",         Rol = Rol.Tanque },
        new() { Clave = "domina",        Nombre = "Domina",        Rol = Rol.Tanque },
        new() { Clave = "doomfist",      Nombre = "Doomfist",      Rol = Rol.Tanque },
        new() { Clave = "dva",           Nombre = "D.Va",          Rol = Rol.Tanque },
        new() { Clave = "echo",          Nombre = "Echo",          Rol = Rol.Daño },
        new() { Clave = "emre",          Nombre = "Emre",          Rol = Rol.Daño },
        new() { Clave = "freja",         Nombre = "Freja",         Rol = Rol.Daño },
        new() { Clave = "genji",         Nombre = "Genji",         Rol = Rol.Daño },
        new() { Clave = "hanzo",         Nombre = "Hanzo",         Rol = Rol.Daño },
        new() { Clave = "hazard",        Nombre = "Hazard",        Rol = Rol.Tanque },
        new() { Clave = "illari",        Nombre = "Illari",        Rol = Rol.Soporte },
        new() { Clave = "jetpack-cat",   Nombre = "Jetpack Cat",   Rol = Rol.Soporte },
        new() { Clave = "junker-queen",  Nombre = "Junker Queen",  Rol = Rol.Tanque },
        new() { Clave = "junkrat",       Nombre = "Junkrat",       Rol = Rol.Daño },
        new() { Clave = "juno",          Nombre = "Juno",          Rol = Rol.Soporte },
        new() { Clave = "kiriko",        Nombre = "Kiriko",        Rol = Rol.Soporte },
        new() { Clave = "lifeweaver",    Nombre = "Lifeweaver",    Rol = Rol.Soporte },
        new() { Clave = "lucio",         Nombre = "Lúcio",         Rol = Rol.Soporte },
        new() { Clave = "mauga",         Nombre = "Mauga",         Rol = Rol.Tanque },
        new() { Clave = "mei",           Nombre = "Mei",           Rol = Rol.Daño },
        new() { Clave = "mercy",         Nombre = "Mercy",         Rol = Rol.Soporte },
        new() { Clave = "mizuki",        Nombre = "Mizuki",        Rol = Rol.Soporte },
        new() { Clave = "moira",         Nombre = "Moira",         Rol = Rol.Soporte },
        new() { Clave = "orisa",         Nombre = "Orisa",         Rol = Rol.Tanque },
        new() { Clave = "pharah",        Nombre = "Pharah",        Rol = Rol.Daño },
        new() { Clave = "ramattra",      Nombre = "Ramattra",      Rol = Rol.Tanque },
        new() { Clave = "reaper",        Nombre = "Reaper",        Rol = Rol.Daño },
        new() { Clave = "reinhardt",     Nombre = "Reinhardt",     Rol = Rol.Tanque },
        new() { Clave = "roadhog",       Nombre = "Roadhog",       Rol = Rol.Tanque },
        new() { Clave = "shion",         Nombre = "Shion",         Rol = Rol.Daño },
        new() { Clave = "sierra",        Nombre = "Sierra",        Rol = Rol.Daño },
        new() { Clave = "sigma",         Nombre = "Sigma",         Rol = Rol.Tanque },
        new() { Clave = "sojourn",       Nombre = "Sojourn",       Rol = Rol.Daño },
        new() { Clave = "soldier-76",    Nombre = "Soldier: 76",   Rol = Rol.Daño },
        new() { Clave = "sombra",        Nombre = "Sombra",        Rol = Rol.Daño },
        new() { Clave = "symmetra",      Nombre = "Symmetra",      Rol = Rol.Daño },
        new() { Clave = "torbjorn",      Nombre = "Torbjörn",      Rol = Rol.Daño },
        new() { Clave = "tracer",        Nombre = "Tracer",        Rol = Rol.Daño },
        new() { Clave = "vendetta",      Nombre = "Vendetta",      Rol = Rol.Daño },
        new() { Clave = "venture",       Nombre = "Venture",       Rol = Rol.Daño },
        new() { Clave = "widowmaker",    Nombre = "Widowmaker",    Rol = Rol.Daño },
        new() { Clave = "winston",       Nombre = "Winston",       Rol = Rol.Tanque },
        new() { Clave = "wrecking-ball", Nombre = "Wrecking Ball", Rol = Rol.Tanque },
        new() { Clave = "wuyang",        Nombre = "Wuyang",        Rol = Rol.Soporte },
        new() { Clave = "zarya",         Nombre = "Zarya",         Rol = Rol.Tanque },
        new() { Clave = "zenyatta",      Nombre = "Zenyatta",      Rol = Rol.Soporte },
    };

    private static readonly Dictionary<string, Heroe> PorClave =
        Todos.ToDictionary(h => h.Clave);

    /// <summary>Busca un héroe por su clave. Devuelve null si no existe.</summary>
    public static Heroe? Por(string clave) =>
        PorClave.TryGetValue(clave, out var heroe) ? heroe : null;

    public static IEnumerable<Heroe> DeRol(Rol rol) => Todos.Where(h => h.Rol == rol);
}
