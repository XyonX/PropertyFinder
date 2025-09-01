using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyFinder.Backend.Models;

namespace PropertyFinder.Backend.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        
        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<(IEnumerable<Property> Properties, int TotalCount)> GetPropertiesAsync(
            int page,
            int pageSize,
            decimal? minPrice,
            decimal? maxPrice,
            int? locationId,
            int? propertyTypeId,
            int? bedrooms,
            int? bathrooms,
            string listingType,
            List<int> features)
        {
            var query = _context.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.Location)
                .Include(p => p.PropertyImages.Where(pi => pi.IsPrimary))
                .AsQueryable();
                
            // Apply filters
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);
                
            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);
                
            if (locationId.HasValue)
                query = query.Where(p => p.LocationId == locationId.Value);
                
            if (propertyTypeId.HasValue)
                query = query.Where(p => p.PropertyTypeId == propertyTypeId.Value);
                
            if (bedrooms.HasValue)
                query = query.Where(p => p.Bedrooms >= bedrooms.Value);
                
            if (bathrooms.HasValue)
                query = query.Where(p => p.Bathrooms >= bathrooms.Value);
                
            if (!string.IsNullOrEmpty(listingType))
                query = query.Where(p => p.ListingType == listingType);
                
            if (features != null && features.Count > 0)
            {
                query = query.Where(p => p.PropertyFeatures
                    .Count(pf => features.Contains(pf.FeatureId)) == features.Count);
            }
            
            var totalCount = await query.CountAsync();
            
            var properties = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                
            return (properties, totalCount);
        }
        
        // Implement other methods...
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.Location)
                .Include(p => p.Owner)
                .Include(p => p.PropertyImages)
                .Include(p => p.PropertyFeatures)
                    .ThenInclude(pf => pf.Feature)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task<Property> CreatePropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }
        
        public async Task UpdatePropertyAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<IEnumerable<PropertyType>> GetPropertyTypesAsync()
        {
            return await _context.PropertyTypes.ToListAsync();
        }
        
        public async Task AddPropertyFeaturesAsync(int propertyId, List<int> featureIds)
        {
            var propertyFeatures = featureIds.Select(featureId => new PropertyFeature
            {
                PropertyId = propertyId,
                FeatureId = featureId
            });
            
            await _context.PropertyFeatures.AddRangeAsync(propertyFeatures);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdatePropertyFeaturesAsync(int propertyId, List<int> featureIds)
        {
            var existingFeatures = await _context.PropertyFeatures
                .Where(pf => pf.PropertyId == propertyId)
                .ToListAsync();
                
            _context.PropertyFeatures.RemoveRange(existingFeatures);
            
            var propertyFeatures = featureIds.Select(featureId => new PropertyFeature
            {
                PropertyId = propertyId,
                FeatureId = featureId
            });
            
            await _context.PropertyFeatures.AddRangeAsync(propertyFeatures);
            await _context.SaveChangesAsync();
        }
        
        public async Task AddPropertyImageAsync(PropertyImage propertyImage)
        {
            await _context.PropertyImages.AddAsync(propertyImage);
            await _context.SaveChangesAsync();
        }
    }
}