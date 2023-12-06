namespace BarbersHub.Service.DTOs.Assets;

public class BarberStyleAssetForResultDto
{
    public long Id { get; set; }
    public long BarberStyleId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
