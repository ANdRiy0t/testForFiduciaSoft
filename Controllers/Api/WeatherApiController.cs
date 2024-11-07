using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestForCompany.Configuration;
using TestForCompany.Models;

namespace TestForCompany.Controllers.Api;

[ApiController]
[Route("api/weather")]
public class WeatherApiController : ControllerBase
{
    private readonly HttpClient _httpClient; 
    
    public WeatherApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Weather");
    }
    
    [HttpGet("city/find")]
    public async Task<List<string>> FindCity([FromQuery] string citySearchKey)
    {
        if(citySearchKey.Length < 3) return new();
        
        var url = $"find?q={citySearchKey}&appid={AppConstants.ApiKey}";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new();
        }
   
        var responseAsString = await response.Content.ReadAsStringAsync();
        
        var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(responseAsString);
        
        if (weatherData?.List != null && weatherData.List.Count > 0)
        {
            return weatherData.List.Select(x=>x.Name).Distinct().ToList();
        }
        
        return new();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery] string citySearchKey)
    {
        if (string.IsNullOrEmpty(citySearchKey))
        {
            return BadRequest("City name is required.");
        }

        var url = $"forecast?q={citySearchKey}&appid={AppConstants.ApiKey}&units=metric";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Unable to get weather data");
        }

        var responseAsString = await response.Content.ReadAsStringAsync();
       
        
        var weatherData = JsonConvert.DeserializeObject<WeatherForecastResponse>(responseAsString);
        
        var today = DateTime.Now.Date.ToString("yyyy-MM-dd");
        var todayWeatherData = weatherData.WeatherList.Where(x => x.DateText.Split(" ").First() == today);

        var viewModel = new
        {
            TempMax = todayWeatherData.OrderByDescending(x=>x.Main.TempMax).First().Main.TempMax,
            TempMin = todayWeatherData.OrderBy(x=>x.Main.TempMin).First().Main.TempMin,
            WindSpeed = todayWeatherData.OrderByDescending(x=>x.WindData.Speed).First().WindData.Speed,
            Description = todayWeatherData.OrderByDescending(x=>x.ProbabilityOfPrecipitation).First().WeatherConditions.First().Description,
            Precipitation = todayWeatherData.OrderByDescending(x=>x.ProbabilityOfPrecipitation).First().ProbabilityOfPrecipitation,
            Name = weatherData.CityData.Name
        };
        return Ok(viewModel);
    }
}