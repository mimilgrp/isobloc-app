namespace IsoblocApp.Models;

public class Bloc
{
    public bool Checked { get; set; }
    public required string Type { get; set; }
    public int Longueur { get; set; }
    public int Hauteur { get; set; }
    public int Epaisseur { get; set; }
    public required string Reservation { get; set; }
}
