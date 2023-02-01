using Domain.Entities.Cities;

namespace Application.Cities.Models.Response;

public class CityModelResponse
{
    public string Name { get; set; }
    public string Uf { get; set; }

    public static implicit operator CityModelResponse(City? city)
    {
        if (city is null) return new();

        return new()
        {
            Name = city.Name, 
            Uf = city.Uf
        };
    }
}