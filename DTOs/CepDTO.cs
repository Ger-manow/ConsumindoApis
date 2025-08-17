using System.Text.Json.Serialization;

public class CoordinatesDTO
{
    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }
}

public class LocationDTO
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("coordinates")]
    public CoordinatesDTO Coordinates { get; set; }
}

public class CepDTO
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("neighborhood")]
    public string Neighborhood { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("service")]
    public string Service { get; set; }

    [JsonPropertyName("location")]
    public LocationDTO Location { get; set; }
}


