using Application.Excel.Models;
using ClosedXML.Excel;

namespace Application.Customers.Models;

public class CustomerRow : Row
{
    public string? Name { get; set; }
    
    public string? Cpf { get; set; }
    
    public int? Age { get; set; }
    
    public string? City { get; set; }
    
    public string? Uf { get; set; }
    
    protected CustomerRow() {}
    
    public static CustomerRow Map(IXLRangeRow row)
    {
        return new ()
        {
            Name = row.Cell(0).GetValue<string>(), 
            Cpf = row.Cell(1).GetValue<string>(),
            Age = row.Cell(2).GetValue<int>(),
            City = row.Cell(3).GetValue<string>(),
            Uf = row.Cell(4).GetValue<string>()
        };
    }
}