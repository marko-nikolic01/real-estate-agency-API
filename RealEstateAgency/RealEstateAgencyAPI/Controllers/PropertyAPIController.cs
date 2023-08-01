using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyAPI.Models;
using RealEstateAgencyAPI.Models.DTO;

namespace RealEstateAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/property")]
    public class PropertyAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PropertyDTO> GetProperties()
        {
            return new List<PropertyDTO> {
                new PropertyDTO { Id = 1, Name = "Beach house"},
                new PropertyDTO { Id = 2, Name = "Appartment"}
            };
        }
    }
}
