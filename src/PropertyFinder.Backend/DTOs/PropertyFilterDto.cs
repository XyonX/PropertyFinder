using System.Collections.Generic;

namespace PropertyFinder.Backend.DTOs
{
    public class PropertyFilterDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? LocationId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public string ListingType { get; set; }
        public List<int> Features { get; set; }
    }
}