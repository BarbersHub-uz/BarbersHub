﻿using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Domain.Entities.BarberShops;
using Microsoft.AspNetCore.Http;

namespace BarbersHub.Service.DTOs.BarberShops.BarberStyles;

public class BarberStyleForCreationDto
{
    public long StyleId { get; set; }
    public long BarberId { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
}
