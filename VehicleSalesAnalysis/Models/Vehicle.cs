using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VehicleSalesAnalysis.Models
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string Manufacturer { get; set; }
        
        // ICollection because I want to be able to manipulate the collection/list with any
        // subclasses available not be limited with List for instance
        [JsonPropertyName("SalesHistory")]
        public ICollection<Sale> Sales { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}