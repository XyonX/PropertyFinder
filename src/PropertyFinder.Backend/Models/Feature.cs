using System.Collections.Generic;

namespace PropertyFinder.Backend.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string IconName { get; set; }

        // Navigation properties
        public ICollection<PropertyFeature> PropertyFeatures { get; set; }
    }
}