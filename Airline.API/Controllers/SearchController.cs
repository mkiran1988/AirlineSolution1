using Airline.API.Data.Repositories.Interfaces;
using Airline.API.Models.DTO;
using Airline.API.Models.Models.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Airline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository searchRepository;
        private readonly ISearchHistoryRepository seearchHistoryRepository;
        private readonly IMapper mapper;


        public SearchController(ISearchRepository searchRepository,ISearchHistoryRepository seearchHistoryRepository, IMapper mapper)
        {
            this.searchRepository = searchRepository;
            this.seearchHistoryRepository = seearchHistoryRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Used to search flights based on the search term
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="criteria">property name/value</param>
        /// <param name="sortBy">sort by </param>
        /// <returns></returns>
        /// <respponse code="200">paged list of all flights matching the search term</respponse>
        [HttpPost]
        public async Task<IActionResult> SearchFlights([FromQuery] string searchTerm, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10,
                                                       [FromQuery] List<string>? criteria = null, [FromQuery] string sortBy = "relevance")
        {
            try
            {
                //max page size
                if (pageSize < 1 || pageSize > 500)
                {
                    return BadRequest("Page size must be between 1 and 500.");
                }
                var criterionPairs = new List<(string Property, string Value)>();
                if (criteria != null && criteria.Count % 2 == 0)
                {

                    // Extract criterion property and value pairs from criteria list
                    for (int i = 0; i < criteria.Count; i += 2)
                    {
                        criterionPairs.Add((criteria[i], criteria[i + 1]));
                    }
                }
                var (flights, totalPages) = await searchRepository.SearchFlights(searchTerm, criterionPairs, pageNumber, pageSize, sortBy);

                try
                {
                    var userID = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                    SearchHistory searchHistory = new SearchHistory()
                    {
                        SearchTime = DateTime.Now,
                        UserId = userID,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        SearchTerm = searchTerm,
                        SortBy = sortBy,
                        Criteria = JsonConvert.SerializeObject(criteria),
                    };
                    //on successful response store the search history 
                    await seearchHistoryRepository.AddHistoryAsync(searchHistory);
                }
                catch
                {
                    //can be used for some logging
                }
                var flightScheduleDTOs = mapper.Map<IEnumerable<FlightScheduleDto>>(flights);
                //deliver search result even if we are unable to save search history
                return Ok(new { Flights = flightScheduleDTOs, TotalPages = totalPages });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("serachHistory")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetSearchHistory()
        {
            try
            {
                //get loggedin user ID 
                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                if(userId == null)
                {
                    return BadRequest("Unable to retive logged in user infrmation");
                }
                var searchHistory = await seearchHistoryRepository.GetUserSearchHistoryAsync(userId);

                if (searchHistory == null || !searchHistory.Any())
                {
                    return NotFound("There is no search history for this user");
                }

                // Map Domain model to DTO
                var searchHistoryDTOs = mapper.Map<IEnumerable<SearchHistoryDto>>(searchHistory);
                return Ok(searchHistoryDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing the request." + ex.Message);
            }
        }
    }
}
