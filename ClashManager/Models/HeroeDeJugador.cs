namespace ClashManager.Models;

/// <summary>Un héroe del pool de un jugador, con el nivel que tiene en el juego.
/// El nivel es fijo: sin API no hay de dónde leerlo, lo edita el propio jugador.</summary>
public class HeroeDeJugador
{
    public Heroe Heroe { get; set; } = new();
    public int Nivel { get; set; }

    public string Nombre => Heroe.Nombre;
    public string Retrato => Heroe.Retrato;
    public string Inicial => Heroe.Inicial;
    public Rol Rol => Heroe.Rol;
    public string NivelTexto => $"Nv. {Nivel}";
}
