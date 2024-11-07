namespace TestForCompany.Models;

public class WeatherResponse
{
    public string Message { get; set; }
    public string Cod { get; set; }
    public int Count { get; set; }
    public List<CityWeatherResponseItem> List { get; set; }
}

public class CityWeatherResponseItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CoordResponseItem Coord { get; set; }
    public MainResponseItem Main { get; set; }
    public WindResponseItem Wind { get; set; }
    public SysResponseItem Sys { get; set; }
    public Weather[] Weather { get; set; }
}

public class CoordResponseItem
{
    public double Lat { get; set; }
    public double Lon { get; set; }
}

public class MainResponseItem
{
    public double Temp { get; set; }
    public double Feels_Like { get; set; }
    public double Temp_Min { get; set; }
    public double Temp_Max { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
}

public class WindResponseItem
{
    public double Speed { get; set; }
    public int Deg { get; set; }
}

public class SysResponseItem
{
    public string Country { get; set; }
}

public class Weather
{
    public int Id { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}
