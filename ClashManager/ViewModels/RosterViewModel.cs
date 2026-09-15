using System.Collections.Generic;
using ClashManager.Models;
using ClashManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClashManager.ViewModels;

public partial class RosterViewModel : ViewModelBase
{
    /// <summary>Formato competitivo del equipo: 6v6, o sea 2 tanques, 2 de daño y 2 soportes.</summary>
    public const int PlantelCompleto = 6;
    private const int PorRol = 2;

    public List<Jugador> Jugadores => DatosDemo.Jugadores;

    [ObservableProperty]
    public partial string NombreEquipo { get; set; }

    public RosterViewModel()
    {
        NombreEquipo = DatosDemo.NombreEquipo;
    }

    partial void OnNombreEquipoChanged(string value)
    {
        DatosDemo.NombreEquipo = value;
    }

    public string Composicion
    {
        get
        {
            var faltantes = new List<string>();

            foreach (var rol in new[] { Rol.Tanque, Rol.Daño, Rol.Soporte })
            {
                int tiene = Jugadores.FindAll(j => j.Rol == rol).Count;
                for (int i = tiene; i < PorRol; i++)
                    faltantes.Add(NombreDeHueco(rol));
            }

            string cabecera = $"{Jugadores.Count} de {PlantelCompleto} titulares (6v6)";

            if (faltantes.Count == 0)
                return cabecera + " · plantel completo";

            string verbo = faltantes.Count == 1 ? "falta" : "faltan";
            return $"{cabecera} · {verbo} {string.Join(" y ", faltantes)}";
        }
    }

    private static string NombreDeHueco(Rol rol) => rol switch
    {
        Rol.Tanque => "un tanque",
        Rol.Daño => "un jugador de daño",
        Rol.Soporte => "un soporte",
        _ => "un jugador",
    };
}
