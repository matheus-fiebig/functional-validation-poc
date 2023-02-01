using Application.Cities.Services;
using Application.Common.Extensions;
using Application.Common.Models;
using Application.Common.Validators;
using Application.Customers.Models.Request;
using Application.Customers.Validators;
using Domain.Entities.Customers;
using Domain.Errors;

namespace Application.Customers.Services;

public class CustomerService : ICustomerService
{
    private readonly ICityService _cityService;

    public CustomerService(ICityService cityService)
    {
        _cityService = cityService;
    }
    
    public ResponseObject CreateCustomer(CreateCustomerRequest customerRequest)
    {
        var cities = _cityService.GetAllCities()
            .ToDictionary(k => k.Name, v => v.Uf);
        
        return customerRequest
            .AsValidator()
            .Validate(customer => EmptyValidator.IsInvalid(customer.Name), $"{CustomerErrors.EmptyField} [NAME]")
            .Validate(customer => EmptyValidator.IsInvalid(customer.Cpf), $"{CustomerErrors.EmptyField} [CPF]")
            .Validate(customer => EmptyValidator.IsInvalid(customer.Age), $"{CustomerErrors.EmptyField} [AGE]")
            .Validate(customer => EmptyValidator.IsInvalid(customer.City), $"{CustomerErrors.EmptyField} [CITY]")
            .Validate(customer => EmptyValidator.IsInvalid(customer.Uf), $"{CustomerErrors.EmptyField} [UF]")
            .Validate(customer => HasDataValidator.IsInvalid(cities!, customer.City), $"{CustomerErrors.InvalidDataCollection} [CITY]")
            .Validate(customer => CpfValidator.IsInvalid(customer.Cpf), $"{CustomerErrors.InvalidCpf}")
            .Match(
                onSuccess: customer => Create(customer),
                onError: errors => ResponseObject.Create(errors)
            );
    }
    
    private Customer Create(CreateCustomerRequest customer)
    {
        var customerDomain = Customer.Create(customer.Name!, customer.Cpf!, customer.Age);
        return customerDomain;
    }
}