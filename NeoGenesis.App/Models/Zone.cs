namespace NeoGenesis.App.Models;

public class Zone
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int SectorId { get; set; }
  public Sector Sector { get; set; } = null!;
}