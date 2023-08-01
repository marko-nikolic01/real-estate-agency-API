using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyAPI.Models;

namespace RealEstateAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/Property")]
    public class PropertyAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Property> GetProperties()
        {
            return new List<Property> {
                new Property { Id = 1, Name = "Beach house"},
                new Property { Id = 2, Name = "Appartment"}
            };
        }
    }
}
