namespace NeoGenesis.App.Models;

public class Dinosaur
{
    public int Id { get; set; }
    public string RegistrationCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Age { get; set; }
    public string DietType { get; set; } = string.Empty;
    public string TrackingDevice { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public int ZoneId { get; set; }
    
    public Zone Zone { get; set; } = null!;
}



