using System.ComponentModel.DataAnnotations;

namespace RealEstateAgencyAPI.Models.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(0.1, Double.MaxValue)]
        public double SquareMeters { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public PropertyDTO()
        {
            Id = 0;
            Name = "";
            SquareMeters = 0;
            Details = "";
            ImageURL = "";
            Type = "";
            Address = "";
            City = "";
            Country = "";
        }
    }
}
