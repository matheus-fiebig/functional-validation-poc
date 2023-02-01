using Application.Cities.Models.Response;

namespace Application.Cities.Services;

public interface ICityService
{
    IEnumerable<CityModelResponse> GetAllCities();
}