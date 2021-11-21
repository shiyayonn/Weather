using System.Text.Json;
using System.Xml.Serialization;

public static class Utilities
{

    public static OpenWeatherCityXmlResponse SingleCityDeserializerXml(string stringResult, ILogger _logger)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(OpenWeatherCityXmlResponse));
        StringReader rdr = new StringReader(stringResult);
        OpenWeatherCityXmlResponse singleCity = (OpenWeatherCityXmlResponse)serializer.Deserialize(rdr);
        _logger.LogDebug($"Deserialization of city {singleCity.city.name} complete");
        return singleCity;
    }

    public static OpenWeatherCityJsonResponse SingleCityDeserializerJson(string stringResult, ILogger _logger)
    {
        OpenWeatherCityJsonResponse singleCity = JsonSerializer.Deserialize<OpenWeatherCityJsonResponse>(stringResult);
        _logger.LogDebug($"Deserialization of city {singleCity.name} complete");
        return JsonSerializer.Deserialize<OpenWeatherCityJsonResponse>(stringResult);
    }


    public static async Task WriteToFolder1(string fileName,string text)
    {
        string folderName = @"c:\Folder1";
        
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderName, fileName)))
        {
            await outputFile.WriteAsync(text);
        }
    }


}