using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyAPI.Data;
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
            return PropertyStorage.properties;
        }

        [HttpGet("id")]
        public PropertyDTO GetProperty(int id)
        {
            return PropertyStorage.properties.FirstOrDefault(property => property.Id == id); ;
        }
    }
}
