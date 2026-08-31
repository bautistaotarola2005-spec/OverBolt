namespace ClashManager.Models;

public class Campeon
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public Rol RolPrincipal { get; set; }
    public int Comodidad { get; set; }
    public string Notas { get; set; } = string.Empty;
    public int JugadorId { get; set; }
}