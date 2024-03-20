using Airline.API.Data.Repositories.Contexts;
using Airline.API.Data.Repositories.Interfaces;
using Airline.API.Models.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airline.API.Data.Repositories.Implementation
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SearchRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        public async Task<(IEnumerable<FlightSchedule> Flights, int TotalPages)> SearchFlights(string searchTerm, List<(string Property, string Value)> criteria, int pageNumber, int pageSize, string sortBy)
        {
           var query = dbContext.FlightSchedules.AsQueryable();

            // Apply full-text search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(f => EF.Functions.Contains(f.FlightNumber, searchTerm) ||
                                         EF.Functions.Contains(f.DepartureAirport, searchTerm) ||
                                         EF.Functions.Contains(f.ArrivalAirport, searchTerm) ||
                                         EF.Functions.Contains(f.Airline, searchTerm) ||
                                         EF.Functions.Contains(f.AircraftType, searchTerm));
            }

            // Apply multiple criteria
            foreach (var criterion in criteria)
            {
                query = query.Where(GetFilterExpression(criterion.Property, criterion.Value));
            }

            // Apply sorting and pagination
            // Apply sorting
            switch (sortBy.ToLower())
            {
                case "relevance":
                    // default sort is by relevance so no need to sort
                    //for this case
                    break;
                case "departuretime":
                    query = query.OrderBy(f => f.DepartureTime);
                    break;
                case "arrivaltime":
                    query = query.OrderBy(f => f.ArrivalTime);
                    break;
                default:
                    throw new ApplicationException("Sorting by Relevance,DepartureTime,ArrivalTime is only supported by the system");
            }
            // Count total records for pagination
            int totalRecords = await query.CountAsync();

            // Calculate total pages based on total records and page size
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if(totalPages <=0)
            {
                return (await query.ToListAsync(), totalPages);
            }
            //if supplied page number is greater than total pages then 
            //last page data willbe returned.
            if (pageNumber > totalPages)
            {
                throw new ApplicationException("Invalid page number");
            }

            var result = await query.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return (result, totalPages);
        }
        private Expression<Func<FlightSchedule, bool>> GetFilterExpression(string property, string value)
        {
            //just handeled for few datatypes based on FlighSchedule Class
            ParameterExpression parameter = Expression.Parameter(typeof(FlightSchedule), "f");
            try
            {
                MemberExpression propertyExpression = Expression.Property(parameter, property);
                ConstantExpression valueExpression;

                // Determine the property type
                Type propertyType = propertyExpression.Type;

                // Handle different data types for comparison
                if (propertyType == typeof(string))
                {
                    valueExpression = Expression.Constant(value);
                }
                else if (propertyType == typeof(int))
                {
                    if (int.TryParse(value, out int intValue))
                    {
                        valueExpression = Expression.Constant(intValue);
                    }
                    else
                    {
                        return f=>false; 
                    }
                }
                else if (propertyType == typeof(decimal))
                {
                    if (decimal.TryParse(value, out decimal decimalValue))
                    {
                        valueExpression = Expression.Constant(decimalValue);
                    }
                    else
                    {
                        return f => false;
                    }
                }
                else if (propertyType == typeof(double))
                {
                    if (double.TryParse(value, out double doubleValue))
                    {
                        valueExpression = Expression.Constant(doubleValue);
                    }
                    else
                    {
                        return f => false;
                    }
                }
                else if (propertyType == typeof(float))
                {
                    if (float.TryParse(value, out float floatValue))
                    {
                        valueExpression = Expression.Constant(floatValue);
                    }
                    else
                    {
                        return f => false;
                    }
                }
                else if (propertyType == typeof(bool))
                {
                    if (bool.TryParse(value, out bool boolValue))
                    {
                        valueExpression = Expression.Constant(boolValue);
                    }
                    else
                    {
                        return f => false;
                    }
                }
                else if (propertyType == typeof(DateTime))
                {
                    if (DateTime.TryParse(value, out DateTime dateTimeValue))
                    {
                        valueExpression = Expression.Constant(dateTimeValue);
                    }
                    else
                    {
                        return f => false;
                    }
                }
                else
                {
                    return f => false;
                }

                // Create the binary expression for comparison
                BinaryExpression binaryExpression = Expression.Equal(propertyExpression, valueExpression);
                return Expression.Lambda<Func<FlightSchedule, bool>>(binaryExpression, parameter);
            }
            catch
            {
                throw new ApplicationException("Request payload is invalid");
            }
        }
    }
}
