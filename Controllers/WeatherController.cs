using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestForCompany.Models;

public class WeatherController : Controller
{
    private readonly ILogger<WeatherController> _logger;
    private readonly HttpClient _httpClient; 

    public WeatherController(ILogger<WeatherController> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("Weather");
    }
    
    [HttpGet("weather")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}