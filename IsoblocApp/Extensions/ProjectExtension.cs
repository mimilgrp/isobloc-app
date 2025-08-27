using IsoblocApp.Models;
using IsoblocApp.Properties;
using System.Text.Json;

namespace IsoblocApp.Extensions;

public static class ProjectExtension
{
    private static readonly string jsonFile = Resources.projectsJSONFile;

    private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

    public static void WriteToFile(this ICollection<Project> projects)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(projects, options);

            File.WriteAllText(jsonFile, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erreur impossible d'écrire dans le fichier '{jsonFile}': {e.Message}");
        }
    }

    public static List<Project> ReadFromFile()
    {
        string jsonString = File.ReadAllText(jsonFile);

        return JsonSerializer.Deserialize<List<Project>>(jsonString) ?? [];
    }
}
