namespace ClashManager.Models;

public class RendimientoJugador
{
    public string BattleTag { get; set; } = string.Empty;
    public Rol Rol { get; set; }
    public int Eliminaciones { get; set; }
    public int Asistencias { get; set; }
    public int Muertes { get; set; }
    public int Dano { get; set; }
    public int Curacion { get; set; }
    public int DanoMitigado { get; set; }

    public string DanoTexto => Dano.ToString("N0");
    public string CuracionTexto => Curacion.ToString("N0");
    public string DanoMitigadoTexto => DanoMitigado.ToString("N0");
}
