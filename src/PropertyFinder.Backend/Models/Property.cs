using System;
using System.Collections.Generic;

namespace PropertyFinder.Backend.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PropertyTypeId { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public decimal? Size { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? YearBuilt { get; set; }
        public string ListingType { get; set; } // For Sale, For Rent
        public string Status { get; set; } // Available, Sold, Rented
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public PropertyType PropertyType { get; set; }
        public Location Location { get; set; }
        public User Owner { get; set; }
        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<PropertyFeature> PropertyFeatures { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Inquiry> Inquiries { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}