﻿namespace BarbersHub.Service.DTOs.Assets;

public class StyleAssetForResultDto
{
    public long Id { get; set; }
    public long StyleId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public bool IsDeleted { get; set; }

}
