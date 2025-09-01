namespace PropertyFinder.Backend.Models
{
    public class PropertyFeature
    {
        public int PropertyId { get; set; }
        public int FeatureId { get; set; }

        // Navigation properties
        public Property Property { get; set; }
        public Feature Feature { get; set; }
    }
}