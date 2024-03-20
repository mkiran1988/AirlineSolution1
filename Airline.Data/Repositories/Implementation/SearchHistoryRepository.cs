using Airline.API.Data.Repositories.Contexts;
using Airline.API.Data.Repositories.Interfaces;
using Airline.API.Models.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Airline.API.Data.Repositories.Implementation
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SearchHistoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddHistoryAsync(SearchHistory searchHistory)
        {
            try
            {
                await dbContext.SearchHistory.AddAsync(searchHistory);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while saving the search history.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while saving the search history.", ex);
            }
        }

        public async Task<IEnumerable<SearchHistory>> GetUserSearchHistoryAsync(string? userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                throw new Exception("unable to fetch current user details");
            }
            try
            {
                return await dbContext.SearchHistory
                    .Where(c => c.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving user search history.", ex);
            }
        }
    }
}
