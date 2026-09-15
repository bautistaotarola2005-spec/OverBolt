namespace OverBolt.Models;

public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string BattleTag { get; set; } = string.Empty;
    public Rol Rol { get; set; }
    public string Rango { get; set; } = string.Empty;
    public int PartidasJugadas { get; set; }
    public bool EsCapitan { get; set; }

    public override string ToString() => $"{BattleTag} ({Rol})";
}
