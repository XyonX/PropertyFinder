using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyFinder.Backend.DTOs;
using PropertyFinder.Backend.Models;

namespace PropertyFinder.Backend.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PagedResultDto<PropertyDto>> GetPropertiesAsync(PropertyFilterDto filterDto);
        Task<PropertyDetailDto> GetPropertyByIdAsync(int id);
        Task<PropertyDto> CreatePropertyAsync(CreatePropertyDto propertyDto, int userId);
        Task<bool> UpdatePropertyAsync(int id, UpdatePropertyDto propertyDto, int userId);
        Task<bool> DeletePropertyAsync(int id, int userId);
        Task<IEnumerable<PropertyTypeDto>> GetPropertyTypesAsync();
        Task<bool> AddPropertyImageAsync(int propertyId, UploadImageDto imageDto, int userId);
    }
}