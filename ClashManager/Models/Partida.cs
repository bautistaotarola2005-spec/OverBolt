using System;

namespace ClashManager.Models;

public class Partida
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Rival { get; set; } = string.Empty;
    public bool EsVictoria { get; set; }
    public TimeSpan Duracion { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public string Notas { get; set; } = string.Empty;

    public string Resultado => EsVictoria ? "Victoria" : "Derrota";
    public string Kda => $"{Kills}/{Deaths}/{Assists}";
}