using Application.Cities.Models.Response;
using Domain.Entities.Cities;

namespace Application.Cities.Services;

public class CityService : ICityService
{
    public IEnumerable<CityModelResponse> GetAllCities()
    {
        return new CityModelResponse[]
        {
            City.Create("São Paulo","SP"),
            City.Create("Rio de Janeiro","RJ"),
            City.Create("Campinas","SP"),
            City.Create("Belo Horizonte","MG")
        };
    }
}