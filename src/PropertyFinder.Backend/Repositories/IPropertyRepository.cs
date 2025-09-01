using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyFinder.Backend.Models;

namespace PropertyFinder.Backend.Data.Repositories
{
    public interface IPropertyRepository
    {
        Task<(IEnumerable<Property> Properties, int TotalCount)> GetPropertiesAsync(
            int page,
            int pageSize,
            decimal? minPrice,
            decimal? maxPrice,
            int? locationId,
            int? propertyTypeId,
            int? bedrooms,
            int? bathrooms,
            string listingType,
            List<int> features);
            
        Task<Property> GetPropertyByIdAsync(int id);
        Task<Property> CreatePropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
        Task<IEnumerable<PropertyType>> GetPropertyTypesAsync();
        Task AddPropertyFeaturesAsync(int propertyId, List<int> featureIds);
        Task UpdatePropertyFeaturesAsync(int propertyId, List<int> featureIds);
        Task AddPropertyImageAsync(PropertyImage propertyImage);
    }
}