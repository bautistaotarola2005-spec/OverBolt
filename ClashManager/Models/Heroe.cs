namespace ClashManager.Models;

/// <summary>Una entrada del catálogo de héroes. No pertenece a ningún jugador:
/// el vínculo jugador-héroe-nivel vive en <see cref="HeroeDeJugador"/>.</summary>
public class Heroe
{
    /// <summary>Identificador estable en minúsculas. Es también el nombre del archivo
    /// de imagen dentro de Assets/heroes/.</summary>
    public string Clave { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;
    public Rol Rol { get; set; }

    public string Retrato => $"avares://ClashManager/Assets/heroes/{Clave}.png";

    /// <summary>Letra de reserva para cuando todavía no está la imagen.</summary>
    public string Inicial => string.IsNullOrEmpty(Nombre) ? "?" : Nombre[..1];
}
