namespace Application.Customers.Models.Request;

public class CreateCustomerRequest
{
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public string? City { get; set; }
    public string? Uf { get; set; }
    public int Age { get; set; }
}