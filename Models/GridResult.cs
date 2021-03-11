using Newtonsoft.Json;
using System.Collections.Generic;

namespace Upstart13.Weather.API.Models
{
    public class GridResult
    {
        [JsonProperty("@context")]
        public List<object> Context { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Geometry1 geometry { get; set; }
        public Properties1 properties { get; set; }
    }

    public class Geometry1
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Distance
    {
        public double value { get; set; }
        public string unitCode { get; set; }
    }

    public class Bearing
    {
        public int value { get; set; }
        public string unitCode { get; set; }
    }

    public class Properties2
    {
        public string city { get; set; }
        public string state { get; set; }
        public Distance distance { get; set; }
        public Bearing bearing { get; set; }
    }

    public class Properties1
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string cwa { get; set; }
        public string forecastOffice { get; set; }
        public string gridId { get; set; }
        public int gridX { get; set; }
        public int gridY { get; set; }
        public string forecast { get; set; }
        public string forecastHourly { get; set; }
        public string forecastGridData { get; set; }
        public string observationStations { get; set; }
        public RelativeLocation relativeLocation { get; set; }
        public string forecastZone { get; set; }
        public string county { get; set; }
        public string fireWeatherZone { get; set; }
        public string timeZone { get; set; }
        public string radarStation { get; set; }
    }

    public class RelativeLocation
    {
        public string type { get; set; }
        public Geometry1 geometry { get; set; }
        public Properties2 properties { get; set; }
    }



}
