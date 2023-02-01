using Domain.Common;

namespace Domain.Entities.Cities;

public class City : Entity<int>
{
    public string? Name { get; set; }
    public string? Uf { get; set; }

    protected City()
    {
        
    }

    public static City Create(string name, string uf)
    {
        return new()
        {
            Name = name, 
            Uf = uf
        };
    }
}