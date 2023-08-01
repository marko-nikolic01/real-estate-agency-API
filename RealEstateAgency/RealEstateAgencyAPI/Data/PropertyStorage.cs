using RealEstateAgencyAPI.Models.DTO;

namespace RealEstateAgencyAPI.Data
{
    public static class PropertyStorage
    {
        public static List<PropertyDTO> properties = new List<PropertyDTO> {
            new PropertyDTO { Id = 1, Name = "Beach house"},
            new PropertyDTO { Id = 2, Name = "Appartment"}
        };
    }
}
