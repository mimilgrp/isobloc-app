using IsoblocApp.Models;
using IsoblocApp.Properties;
using System.Diagnostics;
using System.Globalization;

namespace IsoblocApp.Extensions;

public static class BlocExtension
{
    private static readonly string csvFile = Resources.blocsCSVFile;

    public static void WriteToFile(this ICollection<Bloc> blocs)
    {
        try
        {
            using var writer = new StreamWriter(csvFile);
            writer.WriteLine("Checked;Type;Longueur;Hauteur;Epaisseur;Reservation");

            blocs = [.. blocs.OrderBy(b => b.Type)];

            foreach (var bloc in blocs)
            {
                var line = $"{bloc.Checked};{bloc.Type.ToLower()};{bloc.Longueur};{bloc.Hauteur};{bloc.Epaisseur};{bloc.Reservation.ToLower()}";
                writer.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error writing to file '{csvFile}': {e.Message}");
        }

    }

    public static List<Bloc> ReadFromFile()
    {
        var blocs = new List<Bloc>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        if (File.Exists(csvFile))
        {
            using var reader = new StreamReader(csvFile);
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var elements = line?.Split(';');

                if (elements != null && elements.Length == 6)
                {
                    blocs.Add(new Bloc
                    {
                        Checked = bool.Parse(elements[0]),
                        Type = elements[1].ToUpper(),
                        Longueur = int.Parse(elements[2]),
                        Hauteur = int.Parse(elements[3]),
                        Epaisseur = int.Parse(elements[4]),
                        Reservation = textInfo.ToTitleCase(elements[5].ToLower())
                    });
                }
            }
        }

        return blocs;
    }
}
