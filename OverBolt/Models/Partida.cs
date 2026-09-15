using System;
using System.Collections.Generic;
using System.Linq;

namespace OverBolt.Models;

public class Partida
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Mapa { get; set; } = string.Empty;
    public bool EsVictoria { get; set; }
    public TimeSpan Duracion { get; set; }
    public string Notas { get; set; } = string.Empty;
    public List<RendimientoJugador> Rendimientos { get; set; } = new();

    public string Resultado => EsVictoria ? "Victoria" : "Derrota";
    public string FechaCorta => Fecha.ToString("dd/MM/yyyy");
    public string DuracionCorta => $"{(int)Duracion.TotalMinutes} min";

    public int Eliminaciones => Rendimientos.Sum(r => r.Eliminaciones);
    public int Muertes => Rendimientos.Sum(r => r.Muertes);
    public int Asistencias => Rendimientos.Sum(r => r.Asistencias);

    public string Estadisticas => $"{Eliminaciones}/{Muertes}/{Asistencias}";
}
