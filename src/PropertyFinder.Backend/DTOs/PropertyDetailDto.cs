using System;
using System.Collections.Generic;

namespace PropertyFinder.Backend.DTOs
{
    public class PropertyDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public decimal? Size { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? YearBuilt { get; set; }
        public string ListingType { get; set; }
        public string Status { get; set; }
        public UserDto Owner { get; set; }
        public List<PropertyImageDto> Images { get; set; }
        public List<FeatureDto> Features { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}