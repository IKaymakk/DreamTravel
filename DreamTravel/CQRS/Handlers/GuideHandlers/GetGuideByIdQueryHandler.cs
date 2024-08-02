using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Queries.GuideQueries;
using DreamTravel.CQRS.Results.DestinationResults;
using DreamTravel.CQRS.Results.GuideResults;
using MediatR;

namespace DreamTravel.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.ID);
            return new GetGuideByIdQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
