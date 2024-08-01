using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Queries.DestinationQueries;
using DreamTravel.CQRS.Results.DestinationResults;
using Microsoft.EntityFrameworkCore;

namespace DreamTravel.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                city = x.City,
                duration = x.DayNight,
                personcapacity = x.Capacity,
                price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
