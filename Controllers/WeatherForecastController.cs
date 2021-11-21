namespace Weather.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using static Utilities;


[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration Configuration;

    private static string apiKey;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        _logger = logger;
        Configuration = configuration;
        apiKey = Configuration["ApiKey"];

    }


    [HttpGet("name/{city}")]
    public async Task<IActionResult> GetCityByName(string city, Mode? mode = Mode.json, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/weather?q={city}&appid={apiKey}&mode={mode}&units={units}&lang={lang}";

                _logger.LogInformation($"Making a request to openweather using {uriString}");

                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Request success, response was ${stringResult}");

                if (mode == Mode.xml)
                {
                    OpenWeatherCityXmlResponse singleCityWeatherOutput = SingleCityDeserializerXml(stringResult, _logger);
                    await WriteToFolder1($"{DateTime.Today.ToLongDateString()} {singleCityWeatherOutput.city.name.ToString()} weather", stringResult);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityXmlResponse>(singleCityWeatherOutput));
                }
                else
                {
                    OpenWeatherCityJsonResponse singleCityWeatherOutput = SingleCityDeserializerJson(stringResult, _logger);
                    await WriteToFolder1($"{DateTime.Today.ToLongDateString()} {singleCityWeatherOutput.name} weather", stringResult);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityJsonResponse>(singleCityWeatherOutput));
                }

            }
            catch (HttpRequestException httpRequestException)
            {

                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");

                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetCityById(int id, Mode? mode = Mode.json, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/weather?id={id}&appid={apiKey}&mode={mode}&units={units}&lang={lang}";
                
                _logger.LogInformation($"Making a request to openweather {uriString}");

                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Request success, response was ${stringResult}");

                if (mode == Mode.xml)
                {

                    OpenWeatherCityXmlResponse singleCityWeatherOutput = SingleCityDeserializerXml(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityXmlResponse>(singleCityWeatherOutput));
                }
                else
                {

                    OpenWeatherCityJsonResponse singleCityWeatherOutput = SingleCityDeserializerJson(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityJsonResponse>(singleCityWeatherOutput));
                }
            }
            catch (HttpRequestException httpRequestException)
            {

                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");

                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }

    [HttpGet("coordinates/{lat}/{lon}")]
    public async Task<IActionResult> GetCityByGeoCoordinates(double lat, double lon, Mode? mode = Mode.json, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&mode={mode}&units={units}&lang={lang}";
                
                _logger.LogInformation($"Making a request to openweather {uriString}");

                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Request success, response was ${stringResult}");

                if (mode == Mode.xml)
                {

                    OpenWeatherCityXmlResponse singleCityWeatherOutput = SingleCityDeserializerXml(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityXmlResponse>(singleCityWeatherOutput));
                }
                else
                {

                    OpenWeatherCityJsonResponse singleCityWeatherOutput = SingleCityDeserializerJson(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityJsonResponse>(singleCityWeatherOutput));
                }
            }
            catch (HttpRequestException httpRequestException)
            {

                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");

                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }

    [HttpGet("zipcode/{zipcode}/{countrycode}")]
    public async Task<IActionResult> GetCityByZipCode(string zipcode, string countrycode, Mode? mode = Mode.json, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/weather?zip={zipcode},{countrycode}&appid={apiKey}&mode={mode}&units={units}&lang={lang}";
                
                _logger.LogInformation($"Making a request to openweather {uriString}");

                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Request success, response was ${stringResult}");
        
                if (mode == Mode.xml)
                {

                    OpenWeatherCityXmlResponse singleCityWeatherOutput = SingleCityDeserializerXml(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityXmlResponse>(singleCityWeatherOutput));
                }
                else
                {

                    OpenWeatherCityJsonResponse singleCityWeatherOutput = SingleCityDeserializerJson(stringResult, _logger);
                    return Ok(JsonSerializer.Serialize<OpenWeatherCityJsonResponse>(singleCityWeatherOutput));
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                
                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                
                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }

    // Will be deprecated by 1st January 2022.
    [HttpGet("bbox")]
    public async Task<IActionResult> GetCitiesByRectangleZone(double lon_left, double lat_bottom, double lon_right, double lat_top, double zoom, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/box/city?bbox={lon_left},{lat_bottom},{lon_right},{lat_top},{zoom}&appid={apiKey}&units={units}&lang={lang}";
                
                _logger.LogInformation($"Making a request to openweather {uriString}");
                
                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();

                 _logger.LogInformation($"Request success, response was ${stringResult}");

                OpenWeatherCityBboxJsonResponse rawWeather = JsonSerializer.Deserialize<OpenWeatherCityBboxJsonResponse>(stringResult);

                return Ok(JsonSerializer.Serialize<OpenWeatherCityBboxJsonResponse>(rawWeather));
            }
            catch (HttpRequestException httpRequestException)
            {

                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");

                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }

    [HttpGet("circle")]
    public async Task<IActionResult> GetCitiesByCircle(double lat, double lon, double cnt, Mode? mode = Mode.json, Units? units = Units.metric, Lang? lang = Lang.en)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                string uriString = $"/data/2.5/find?lat={lat}&lon={lon}&cnt={cnt}&appid={apiKey}&mode={mode}&units={units}&lang={lang}";
                
                _logger.LogInformation($"Making a request to openweather {uriString}");

                var response = await client.GetAsync(uriString);
                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Request success, response was ${stringResult}");

                OpenWeatherCityCircleJsonResponse rawWeather = JsonSerializer.Deserialize<OpenWeatherCityCircleJsonResponse>(stringResult);

                return Ok(JsonSerializer.Serialize<OpenWeatherCityCircleJsonResponse>(rawWeather));
            }
            catch (HttpRequestException httpRequestException)
            {

                _logger.LogError($"Error getting weather from OpenWeather: {httpRequestException.Message}");

                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");

            }
        }
    }


}
