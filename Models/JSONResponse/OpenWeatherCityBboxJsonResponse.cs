
public class OpenWeatherCityBboxJsonResponse {
    public int cod {get; set;}
    public double calctime {get; set;}
    public int cnt {get; set;}
    public IEnumerable<OpenWeatherCityJsonResponse> list { get; set;}
}