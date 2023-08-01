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
        [HttpGet(Name = "GetProperties")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyDTO>))]
        public ActionResult GetProperties()
        {
            return Ok(PropertyStorage.properties);
        }

        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> GetProperty(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var property = PropertyStorage.properties.FirstOrDefault(property => property.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpPost(Name = "CreateProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PropertyDTO> CreateProperty([FromBody]PropertyDTO propertyDTO)
        {
            if (PropertyStorage.properties.FirstOrDefault(property => property.Name == propertyDTO.Name) != null)
            {
                ModelState.AddModelError("CustomError", "Property already exists!");
                return BadRequest(ModelState);
            }
            if (propertyDTO == null)
            {
                return BadRequest(propertyDTO);
            }
            if (propertyDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            propertyDTO.Id = PropertyStorage.properties.OrderByDescending(property => property.Id).FirstOrDefault().Id + 1;
            PropertyStorage.properties.Add(propertyDTO);
            return CreatedAtRoute("GetProperty", new { id = propertyDTO.Id }, propertyDTO);
        }
    }
}
