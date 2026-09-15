using System;
using System.Collections.Generic;
using System.Linq;
using ClashManager.Models;

namespace ClashManager.Services;

public static class DatosDemo
{
    /// <summary>Nombre del equipo. Lo define el capitán desde la pantalla de Roster.</summary>
    public static string NombreEquipo { get; set; } = "Sin nombre";

    public static List<Usuario> Usuarios { get; } = new()
    {
        new Usuario("capitan", "overbolt2026"),
    };

    public static List<Jugador> Jugadores { get; } = new()
    {
        new Jugador { Id = 1, Nombre = "Bautista", BattleTag = "Marvin", Rol = Rol.Daño, Rango = "Oro 2", PartidasJugadas = 14, EsCapitan = true },
        new Jugador { Id = 2, Nombre = "Norli", BattleTag = "Norli", Rol = Rol.Soporte, Rango = "Platino 4", PartidasJugadas = 14 },
        new Jugador { Id = 3, Nombre = "Zabala", BattleTag = "Zabala", Rol = Rol.Tanque, Rango = "Diamante 4", PartidasJugadas = 14 },
        new Jugador { Id = 4, Nombre = "Lucas", BattleTag = "Lucas", Rol = Rol.Daño, Rango = "Oro 3", PartidasJugadas = 13 },
    };

    private static HeroeDeJugador H(string clave, int nivel) => new()
    {
        // Si una clave no existe en el catálogo se muestra la clave cruda en vez de romper.
        Heroe = CatalogoHeroes.Por(clave) ?? new Heroe { Clave = clave, Nombre = clave },
        Nivel = nivel,
    };

    private static List<Heroe> C(params string[] claves) =>
        claves.Select(c => CatalogoHeroes.Por(c) ?? new Heroe { Clave = c, Nombre = c }).ToList();

    /// <summary>Pool de cada jugador con el nivel de cada héroe. Valores fijos: sin API
    /// no hay de dónde leerlos, más adelante los edita el propio jugador.</summary>
    public static Dictionary<string, List<HeroeDeJugador>> PoolPorJugador { get; } = new()
    {
        ["Marvin"] = new() { H("genji", 87), H("tracer", 62), H("sombra", 41), H("echo", 28), H("reaper", 19) },
        ["Lucas"]  = new() { H("sojourn", 74), H("ashe", 66), H("cassidy", 38), H("widowmaker", 22), H("junkrat", 15) },
        ["Zabala"] = new() { H("reinhardt", 91), H("winston", 70), H("sigma", 45), H("zarya", 33), H("dva", 24) },
        ["Norli"]  = new() { H("ana", 83), H("kiriko", 68), H("lucio", 52), H("brigitte", 30), H("zenyatta", 17) },
    };

    /// <summary>Composiciones meta de referencia para 6v6 (2 tanques, 2 de daño, 2 soportes).</summary>
    public static List<ComposicionEquipo> ComposicionesMeta { get; } = new()
    {
        new ComposicionEquipo
        {
            Nombre = "Dive",
            Tipo = "Meta",
            Descripcion = "Entrada rápida sobre la línea trasera rival. Pide coordinación en el salto.",
            Tanques  = C("winston", "dva"),
            Danos    = C("genji", "tracer"),
            Soportes = C("lucio", "ana"),
        },
        new ComposicionEquipo
        {
            Nombre = "Poke",
            Tipo = "Meta",
            Descripcion = "Desgaste a distancia antes de entrar. Fuerte en mapas abiertos y pasillos largos.",
            Tanques  = C("sigma", "orisa"),
            Danos    = C("ashe", "widowmaker"),
            Soportes = C("baptiste", "zenyatta"),
        },
    };

    private static RendimientoJugador R(string tag, Rol rol, int e, int a, int m, int dano, int cur, int mit) =>
        new() { BattleTag = tag, Rol = rol, Eliminaciones = e, Asistencias = a, Muertes = m, Dano = dano, Curacion = cur, DanoMitigado = mit };

    public static List<Partida> Partidas { get; } = new()
    {
        new Partida
        {
            Id = 1, Fecha = new DateTime(2026, 8, 28), Mapa = "King's Row", EsVictoria = true,
            Duracion = TimeSpan.FromMinutes(22), Notas = "Buen control del punto en la última pelea.",
            Rendimientos =
            {
                R("Zabala", Rol.Tanque,  24, 26,  9,  9800,     0, 14200),
                R("Marvin", Rol.Daño,    28, 14,  8, 13400,     0,   900),
                R("Lucas",  Rol.Daño,    22, 12, 10, 11200,     0,   700),
                R("Norli",  Rol.Soporte, 11, 34,  7,  4300, 13800,   400),
            }
        },
        new Partida
        {
            Id = 2, Fecha = new DateTime(2026, 8, 24), Mapa = "Ilios", EsVictoria = false,
            Duracion = TimeSpan.FromMinutes(16), Notas = "Perdimos la primera pelea y nunca recuperamos ventaja de ultimates.",
            Rendimientos =
            {
                R("Zabala", Rol.Tanque,  14, 17, 12,  6200,    0,  9100),
                R("Marvin", Rol.Daño,    16,  9, 11,  8100,    0,   600),
                R("Lucas",  Rol.Daño,    12,  8, 13,  6800,    0,   500),
                R("Norli",  Rol.Soporte,  7, 21, 10,  2900, 9200,   300),
            }
        },
        new Partida
        {
            Id = 3, Fecha = new DateTime(2026, 8, 19), Mapa = "Ruta 66", EsVictoria = true,
            Duracion = TimeSpan.FromMinutes(25), Notas = "Gran pelea en el último punto de control.",
            Rendimientos =
            {
                R("Zabala", Rol.Tanque,  27, 31, 10, 11400,     0, 16800),
                R("Marvin", Rol.Daño,    33, 16,  9, 15600,     0,  1100),
                R("Lucas",  Rol.Daño,    26, 14, 11, 12900,     0,   800),
                R("Norli",  Rol.Soporte, 13, 39,  8,  5100, 16200,   500),
            }
        },
        new Partida
        {
            Id = 4, Fecha = new DateTime(2026, 8, 10), Mapa = "Circuito Real", EsVictoria = true,
            Duracion = TimeSpan.FromMinutes(18), Notas = "Presión constante sobre el acompañante desde el inicio.",
            Rendimientos =
            {
                R("Zabala", Rol.Tanque,  19, 22,  6,  8100,     0, 12400),
                R("Marvin", Rol.Daño,    24, 11,  5, 10800,     0,   700),
                R("Lucas",  Rol.Daño,    18, 10,  7,  8900,     0,   600),
                R("Norli",  Rol.Soporte,  9, 28,  5,  3600, 11400,   300),
            }
        },
        new Partida
        {
            Id = 5, Fecha = new DateTime(2026, 7, 30), Mapa = "Numbani", EsVictoria = false,
            Duracion = TimeSpan.FromMinutes(20), Notas = "Composición desbalanceada, jugamos sin segundo soporte.",
            Rendimientos =
            {
                R("Zabala", Rol.Tanque,  15, 19, 14,  7300,     0, 10600),
                R("Marvin", Rol.Daño,    18, 10, 13,  9200,     0,   700),
                R("Lucas",  Rol.Daño,    14,  9, 15,  7600,     0,   500),
                R("Norli",  Rol.Soporte,  8, 24, 12,  3300, 10100,   400),
            }
        },
    };
}
