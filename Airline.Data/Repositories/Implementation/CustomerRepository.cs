using Airline.API.Data.Repositories.Contexts;
using Airline.API.Data.Repositories.Interfaces;
using Airline.API.Models.Models.Domain;

namespace Airline.API.Data.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        public async Task SaveCustomerDetailsAsync(CustomerDetails details)
        {
            try
            {
                await dbContext.CustomerDetails.AddAsync(details);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to save customer details to the database.", ex);
            }
        }
    }
}
