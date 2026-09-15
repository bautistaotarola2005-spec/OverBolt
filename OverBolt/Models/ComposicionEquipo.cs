using System.Collections.Generic;
using System.Linq;

namespace OverBolt.Models;

public class ComposicionEquipo
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;

    public List<Heroe> Tanques { get; set; } = new();
    public List<Heroe> Danos { get; set; } = new();
    public List<Heroe> Soportes { get; set; } = new();

    /// <summary>Texto calculado: qué tanto encaja la composición con el pool del equipo.</summary>
    public string Afinidad { get; set; } = string.Empty;

    public bool EsSugerida => Tipo != "Meta";

    public IEnumerable<Heroe> Todos => Tanques.Concat(Danos).Concat(Soportes);
}
