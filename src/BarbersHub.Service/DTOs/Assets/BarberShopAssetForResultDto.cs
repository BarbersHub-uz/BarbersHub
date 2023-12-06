namespace BarbersHub.Service.DTOs.Assets;

public class BarberShopAssetForResultDto
{
    public long Id { get; set; }
    public long BarberShopId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
