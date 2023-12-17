namespace BarbersHub.Service.DTOs.Assets;

public class BarberAssetForResultDto
{
    public long Id { get; set; }
    public long BarberId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public bool IsDeleted { get; set; } 
}
