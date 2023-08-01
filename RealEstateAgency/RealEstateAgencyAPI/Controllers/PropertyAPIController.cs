using Microsoft.AspNetCore.JsonPatch;
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

        [HttpDelete("{id:int}", Name = "DeleteProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProperty(int id)
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
            PropertyStorage.properties.Remove(property);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProperty(int id, [FromBody] PropertyDTO propertyDTO)
        {
            if (propertyDTO == null || id != propertyDTO.Id)
            {
                return BadRequest();
            }
            var property = PropertyStorage.properties.FirstOrDefault(property => property.Id == id);
            property.Name = propertyDTO.Name;
            property.SquareMeters = propertyDTO.SquareMeters;
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "PatchProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PatchProperty(int id, JsonPatchDocument<PropertyDTO> propertyDTO)
        {
            if (propertyDTO == null || id == 0)
            {
                return BadRequest();
            }
            var property = PropertyStorage.properties.FirstOrDefault(property => property.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            propertyDTO.ApplyTo(property, ModelState);
            return NoContent();
        }
    }
}
