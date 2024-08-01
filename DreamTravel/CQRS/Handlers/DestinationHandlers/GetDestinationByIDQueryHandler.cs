using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Queries.DestinationQueries;
using DreamTravel.CQRS.Results.DestinationResults;

namespace DreamTravel.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                destinationid = values.DestinationID,
                city = values.City,
                duration = values.DayNight,
                price = values.Price
            };
        }
    }
}
