
public class OpenWeatherCityCircleJsonResponse {
    public string message {get; set;}
    public string cod {get; set;}
    public int count {get; set;}
    public IEnumerable<OpenWeatherCityJsonResponse> list { get; set;}
}