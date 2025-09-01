using System;
using System.Collections.Generic;

namespace PropertyFinder.Backend.DTOs
{
    public class PropertyDto
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
        public string ListingType { get; set; }
        public string Status { get; set; }
        public string OwnerName { get; set; }
        public string PrimaryImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}