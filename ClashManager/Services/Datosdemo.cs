using System;
using System.Collections.Generic;
using ClashManager.Models;

namespace ClashManager.Services;

public static class DatosDemo
{
    public static List<Usuario> Usuarios { get; } = new()
    {
        new Usuario("capitan", "clash2026"),
    };

    public static List<Jugador> Jugadores { get; } = new()
    {
        new Jugador { Id = 1, Nombre = "Bautista", NombreInvocador = "Marvin", Rol = Rol.Support, Rango = "Oro II", PartidasJugadas = 14, EsCapitan = true },
        new Jugador { Id = 2, Nombre = "Norli", NombreInvocador = "Norli", Rol = Rol.Mid, Rango = "Platino IV", PartidasJugadas = 14 },
        new Jugador { Id = 3, Nombre = "Zabala", NombreInvocador = "Zabala", Rol = Rol.Jungla, Rango = "Diamante IV", PartidasJugadas = 14 },
        new Jugador { Id = 4, Nombre = "Lucas", NombreInvocador = "Lucas", Rol = Rol.Top, Rango = "Oro III", PartidasJugadas = 13 },
    };

    public static List<Partida> Partidas { get; } = new()
    {
        new Partida { Id = 1, Fecha = new DateTime(2026, 8, 28), Rival = "Ganks de Barrio", EsVictoria = true, Duracion = TimeSpan.FromMinutes(32), Kills = 18, Deaths = 9, Assists = 24, Notas = "Buen control de objetivos en la fase tardía." },
        new Partida { Id = 2, Fecha = new DateTime(2026, 8, 24), Rival = "Old School Gamers", EsVictoria = false, Duracion = TimeSpan.FromMinutes(28), Kills = 12, Deaths = 15, Assists = 10, Notas = "Mal inicio de partida, diferencia temprana." },
        new Partida { Id = 3, Fecha = new DateTime(2026, 8, 19), Rival = "Los Intocables", EsVictoria = true, Duracion = TimeSpan.FromMinutes(35), Kills = 22, Deaths = 11, Assists = 30, Notas = "Gran teamfight en el Barón." },
        new Partida { Id = 4, Fecha = new DateTime(2026, 8, 10), Rival = "Nexus Break", EsVictoria = true, Duracion = TimeSpan.FromMinutes(25), Kills = 15, Deaths = 6, Assists = 19, Notas = "Snowball desde el early game." },
        new Partida { Id = 5, Fecha = new DateTime(2026, 7, 30), Rival = "Runterra FC", EsVictoria = false, Duracion = TimeSpan.FromMinutes(30), Kills = 9, Deaths = 14, Assists = 8, Notas = "Draft desbalanceado." },
    };
}
