using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyFinder.Backend.DTOs;
using PropertyFinder.Backend.Services.Interfaces;

namespace PropertyFinder.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetProperties([FromQuery] PropertyFilterDto filterDto)
        {
            var properties = await _propertyService.GetPropertiesAsync(filterDto);
            return Ok(properties);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDetailDto>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            
            if (property == null)
                return NotFound();
                
            return Ok(property);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PropertyDto>> CreateProperty(CreatePropertyDto propertyDto)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            
            var createdProperty = await _propertyService.CreatePropertyAsync(propertyDto, userId);
            
            return CreatedAtAction(nameof(GetProperty), new { id = createdProperty.Id }, createdProperty);
        }
        
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, UpdatePropertyDto propertyDto)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            
            var success = await _propertyService.UpdatePropertyAsync(id, propertyDto, userId);
            
            if (!success)
                return NotFound();
                
            return NoContent();
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            
            var success = await _propertyService.DeletePropertyAsync(id, userId);
            
            if (!success)
                return NotFound();
                
            return NoContent();
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<PropertyTypeDto>>> GetPropertyTypes()
        {
            var propertyTypes = await _propertyService.GetPropertyTypesAsync();
            return Ok(propertyTypes);
        }
        
        [Authorize]
        [HttpPost("{id}/images")]
        public async Task<IActionResult> UploadPropertyImage(int id, [FromForm] UploadImageDto imageDto)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            
            var success = await _propertyService.AddPropertyImageAsync(id, imageDto, userId);
            
            if (!success)
                return BadRequest();
                
            return Ok();
        }
    }
}