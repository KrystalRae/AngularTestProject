using Newtonsoft.Json;

namespace EverWealth.Models
{
    // Used a Json to C# class converter to quickly build the more complicated object model.
    public class Location
    {
        public string Name { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }

    public class Current
    {
        [JsonProperty("temp_c")]
        public double Temp { get; set; }

        public Condition Condition { get; set; }

        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }

        public int Humidity { get; set; }
        public double Uv { get; set; }
    }

    public class WeatherInfo
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public string Date { get; set; }
        public string Risk { get; set; }
    }
}
