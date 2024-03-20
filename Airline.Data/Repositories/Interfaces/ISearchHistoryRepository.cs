using Airline.API.Models.Models.Domain;

namespace Airline.API.Data.Repositories.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task  AddHistoryAsync(SearchHistory searchHistory);
        Task<IEnumerable<SearchHistory>> GetUserSearchHistoryAsync(string userId);
    }
}
