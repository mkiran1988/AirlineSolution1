using Airline.API.Models.DTO;
using Airline.API.Models.Models.Domain;
using AutoMapper;
namespace Airline.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SearchHistory, SearchHistoryDto>();
            CreateMap<FlightSchedule, FlightScheduleDto>();

            // Add more mappings if needed
        }
    }
}




