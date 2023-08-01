using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAgencyAPI.Data;
using RealEstateAgencyAPI.Models;
using RealEstateAgencyAPI.Models.DTO;

namespace RealEstateAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/property")]
    public class PropertyAPIController : ControllerBase
    {
        private readonly ILogger<PropertyAPIController> _logger;
        private readonly ApplicationDbContext _db;
        public PropertyAPIController(ILogger<PropertyAPIController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _logger.LogInformation("Property count:" + _db.Properties.Count());
        }

        

        [HttpGet(Name = "GetProperties")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Property>))]
        [Produces("application/json")]
        public ActionResult GetProperties()
        {
            _logger.LogInformation("Getting all poperties...");
            return Ok(_db.Properties);
        }



        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<PropertyDTO> GetProperty(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error: Couldn't get a property with an ID of 0.");
                return BadRequest();
            }
            var property = _db.Properties.FirstOrDefault(property => property.Id == id);
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
        [Produces("application/json")]
        public ActionResult<PropertyDTO> CreateProperty([FromBody]PropertyDTO propertyDTO)
        {
            if (_db.Properties.FirstOrDefault(property => property.Name == propertyDTO.Name) != null)
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
            _db.Properties.Add(new Property {
                Name = propertyDTO.Name,
                SquareMeters = propertyDTO.SquareMeters,
                Details = propertyDTO.Details,
                ImageURL = propertyDTO.ImageURL,
                Type = propertyDTO.Type,
                Address = propertyDTO.Address,
                City = propertyDTO.City,
                Country = propertyDTO.Country,
                CreatedDate = DateTime.Now
            });
            _db.SaveChanges();
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
            var property = _db.Properties.FirstOrDefault(property => property.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            _db.Properties.Remove(property);
            _db.SaveChanges();
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
            var property = _db.Properties.AsNoTracking().FirstOrDefault(property => property.Id == id);
            Property model = new Property
            {
                Id = id,
                Name = propertyDTO.Name,
                SquareMeters = propertyDTO.SquareMeters,
                Details = propertyDTO.Details,
                ImageURL = propertyDTO.ImageURL,
                Type = propertyDTO.Type,
                Address = propertyDTO.Address,
                City = propertyDTO.City,
                Country = propertyDTO.Country
            };
            _db.Properties.Update(model);
            _db.SaveChanges();
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
            var property = _db.Properties.AsNoTracking().FirstOrDefault(property => property.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            PropertyDTO modelDTO = new PropertyDTO
            {
                Id = property.Id,
                Name = property.Name,
                SquareMeters = property.SquareMeters,
                Details = property.Details,
                ImageURL = property.ImageURL,
                Type = property.Type,
                Address = property.Address,
                City = property.City,
                Country = property.Country
            };
            propertyDTO.ApplyTo(modelDTO, ModelState);
            Property model = new Property
            {
                Id = modelDTO.Id,
                Name = modelDTO.Name,
                SquareMeters = modelDTO.SquareMeters,
                Details = modelDTO.Details,
                ImageURL = modelDTO.ImageURL,
                Type = modelDTO.Type,
                Address = modelDTO.Address,
                City = modelDTO.City,
                Country = modelDTO.Country
            };
            _db.Properties.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
