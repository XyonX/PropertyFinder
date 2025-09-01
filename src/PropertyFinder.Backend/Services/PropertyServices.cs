using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PropertyFinder.Backend.DTOs;
using PropertyFinder.Backend.Models;
using PropertyFinder.Backend.Data.Repositories;
using PropertyFinder.Backend.Services.Interfaces;

namespace PropertyFinder.Backend.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        
        public PropertyService(
            IPropertyRepository propertyRepository,
            IMapper mapper,
            IImageService imageService)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _imageService = imageService;
        }
        
        public async Task<PagedResultDto<PropertyDto>> GetPropertiesAsync(PropertyFilterDto filterDto)
        {
            var (properties, totalCount) = await _propertyRepository.GetPropertiesAsync(
                filterDto.Page,
                filterDto.PageSize,
                filterDto.MinPrice,
                filterDto.MaxPrice,
                filterDto.LocationId,
                filterDto.PropertyTypeId,
                filterDto.Bedrooms,
                filterDto.Bathrooms,
                filterDto.ListingType,
                filterDto.Features
            );
            
            var propertyDtos = _mapper.Map<IEnumerable<PropertyDto>>(properties);
            
            return new PagedResultDto<PropertyDto>
            {
                Items = propertyDtos,
                TotalCount = totalCount,
                Page = filterDto.Page,
                PageSize = filterDto.PageSize
            };
        }
        
        // Implement other methods...
    }
}