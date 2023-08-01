﻿using System.ComponentModel.DataAnnotations;

namespace RealEstateAgencyAPI.Models.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public double SquareMeters { get; set; }
    }
}
