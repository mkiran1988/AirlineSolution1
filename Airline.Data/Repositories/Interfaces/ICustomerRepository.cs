
using Airline.API.Models.Models.Domain;

namespace Airline.API.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task SaveCustomerDetailsAsync(CustomerDetails details);
    }
}
