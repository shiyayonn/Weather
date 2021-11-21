
using System.Xml.Serialization;

[XmlRoot(ElementName = "current")]
public class OpenWeatherCityXmlResponse
{

    [XmlElement("city")]
    public City city { get; set; }

    [XmlElement("temperature")]
    public Temperature temperature { get; set; }

    [XmlElement("feels_like")]
    public FeelsLike feelsLike { get; set; }

    [XmlElement("humidity")]
    public Humidity humidity { get; set; }

    [XmlElement("pressure")]
    public Pressure pressure { get; set; }

    [XmlElement("wind")]
    public WindXml wind { get; set; }

    [XmlElement( "clouds")]
    public CloudsXml clouds { get; set; }

    [XmlElement("visibility")]
    public Visibility visibility { get; set; }

    [XmlElement("precipitation")]
    public Precipitation precipitation { get; set; }

    [XmlElement("weather")]
    public WeatherXml weather { get; set; }

    [XmlElement("lastupdate")]
    public LastUpdate lastUpdate { get; set; }








}
public class City
{
    [XmlAttribute("id")]
    public int id { get; set; }

    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlElement("coord")]
    public Coordinates coord { get; set; }

    [XmlElement("country")]
    public string country { get; set; }

    [XmlElement("timezone")]
    public string timezone { get; set; }

    [XmlElement("sun")]
    public Sun sun { get; set; }


}
public class Temperature
{
    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("min")]
    public double min { get; set; }

    [XmlAttribute("max")]
    public double max { get; set; }

    [XmlAttribute("unit")]
    public string unit { get; set; }

}

public class Sun
{
    [XmlAttribute("sunrise")]
    public DateTime sunrise { get; set; }

    [XmlAttribute("sunset")]
    public DateTime sunset { get; set; }
}

public class FeelsLike
{
    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("unit")]
    public string unit { get; set; }
}

public class Humidity
{

    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("unit")]
    public string unit { get; set; }
}

public class Pressure
{
    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("unit")]
    public string unit { get; set; }
}

public class WindXml
{

    [XmlElement("speed")]
    public Speed speed { get; set; }

    [XmlElement("direction")]
    public Direction direction { get; set; }

}
public class Speed
{

    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("unit")]
    public string unit { get; set; }

    [XmlAttribute("name")]
    public string name { get; set; }
}
public class Direction
{

    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("code")]
    public string code { get; set; }

    [XmlAttribute("name")]
    public string name { get; set; }

}
public class CloudsXml
{

    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("name")]
    public string name { get; set; }
}
public class Visibility
{

    [XmlAttribute("value")]
    public double value { get; set; }
}
public class Precipitation
{

    [XmlAttribute("value")]
    public double value { get; set; }

    [XmlAttribute("mode")]
    public string mode { get; set; }
}
public class WeatherXml
{

    [XmlAttribute("number")]
    public int number { get; set; }

    [XmlAttribute("value")]
    public string value { get; set; }

    [XmlAttribute("icon")]
    public string icon { get; set; }

}

public class LastUpdate
{

    [XmlAttribute("value")]
    public DateTime value { get; set; }
}
