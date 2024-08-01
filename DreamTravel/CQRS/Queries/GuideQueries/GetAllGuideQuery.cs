using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Results.DestinationResults;
using DreamTravel.CQRS.Results.GuideResults;
using MediatR;

namespace DreamTravel.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
