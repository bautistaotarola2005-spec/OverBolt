using System.Collections.Generic;
using ClashManager.Models;
using ClashManager.Services;

namespace ClashManager.ViewModels;

public class RosterViewModel : ViewModelBase
{
    public List<Jugador> Jugadores => DatosDemo.Jugadores;
}
