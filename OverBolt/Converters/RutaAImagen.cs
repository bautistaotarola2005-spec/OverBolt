using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace OverBolt.Converters;

/// <summary>
/// Convierte una ruta avares:// en un Bitmap para enlazarla desde un Binding.
/// Avalonia resuelve Source="/Assets/x.png" escrito literal en el XAML, pero no una
/// ruta que llega por binding, de ahí este converter.
/// Si el archivo no está devuelve null en vez de explotar, así un héroe todavía sin
/// imagen no tira la aplicación abajo.
/// </summary>
public class RutaAImagen : IValueConverter
{
    public static readonly RutaAImagen Instancia = new();

    // Los bitmaps se reusan entre navegaciones en vez de decodificarse de nuevo cada vez.
    private static readonly Dictionary<string, Bitmap?> Cache = new();

    public object? Convert(object? value, Type tipoDestino, object? parametro, CultureInfo cultura)
    {
        if (value is not string ruta || string.IsNullOrWhiteSpace(ruta))
            return null;

        if (Cache.TryGetValue(ruta, out var guardado))
            return guardado;

        Bitmap? bitmap = null;
        try
        {
            var uri = new Uri(ruta);
            if (AssetLoader.Exists(uri))
                bitmap = new Bitmap(AssetLoader.Open(uri));
        }
        catch
        {
            bitmap = null;
        }

        Cache[ruta] = bitmap;
        return bitmap;
    }

    public object? ConvertBack(object? value, Type tipoDestino, object? parametro, CultureInfo cultura)
        => throw new NotSupportedException();
}
