using Application.Common.Models;
using Application.Customers.Models.Request;

namespace Application.Customers.Services;

public interface ICustomerService
{
    ResponseObject CreateCustomer(CreateCustomerRequest customerRequest);
}