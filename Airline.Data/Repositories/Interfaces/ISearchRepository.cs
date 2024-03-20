using Airline.API.Models.Models.Domain;

namespace Airline.API.Data.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        Task<(IEnumerable<FlightSchedule> Flights, int TotalPages)> SearchFlights(string searchTerm, List<(string Property, string Value)> criteria, int pageNumber, int pageSize, string sortBy);
    }
}
