using Domain.Common;
using Domain.Entities.Cities;

namespace Domain.Entities.Customers;

public class Customer : Entity<int>
{
    public string? Name { get; set; }
    
    public string? Cpf { get; set; }
    
    public int? Age { get; set; }
    
    public int CityId { get; set; }
    
    public virtual City? City { get; set; }
    
    protected Customer()
    {
        
    }

    public static Customer Create(string name, string cpf, int age)
    {
        return new()
        {
            Name = name, 
            Cpf = cpf, 
            Age = age
        };
    }
}