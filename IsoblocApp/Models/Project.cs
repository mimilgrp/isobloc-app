namespace IsoblocApp.Models;

public class Project
{
    public required string Name { get; set; }
    public required string Filepath { get; set; }
    public DateTime Date { get; set; }
    public List<Result>? Results { get; set; }

    public int TotalBlocAmount => Results?.Aggregate(0, (acc, val) => acc + val.Quantite) ?? 0;
    public int StandardBlocAmount => Results?.Where(result => !result.Bloc.Type.StartsWith('S')).Aggregate(0, (acc, val) => acc + val.Quantite) ?? 0;
    public int SpecialBlocAmount => Results?.Where(result => result.Bloc.Type.StartsWith('S')).Aggregate(0, (acc, val) => acc + val.Quantite) ?? 0;
}
