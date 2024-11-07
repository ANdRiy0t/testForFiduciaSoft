using Newtonsoft.Json;

namespace TestForCompany.Models
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coordinates { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class WeatherForecast
    {
        [JsonProperty("dt")]
        public int DateTimeUnix { get; set; }

        [JsonProperty("main")]
        public MainWeatherData Main { get; set; }

        [JsonProperty("weather")]
        public List<WeatherCondition> WeatherConditions { get; set; }

        [JsonProperty("clouds")]
        public Clouds CloudData { get; set; }

        [JsonProperty("wind")]
        public Wind WindData { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("pop")]
        public double ProbabilityOfPrecipitation { get; set; }

        [JsonProperty("sys")]
        public Sys System { get; set; }

        [JsonProperty("dt_txt")]
        public string DateText { get; set; }

        [JsonProperty("rain")]
        public Rain RainData { get; set; }
    }

    public class MainWeatherData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("sea_level")]
        public int SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public int GroundLevel { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }

    public class Rain
    {
        [JsonProperty("3h")]
        public double ThreeHour { get; set; }
    }

    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public class WeatherCondition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Degree { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }

    public class WeatherForecastResponse
    {
        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public int Message { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("list")]
        public List<WeatherForecast> WeatherList { get; set; }

        [JsonProperty("city")]
        public City CityData { get; set; }
    }
}
