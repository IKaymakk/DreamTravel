using DreamTravel.CQRS.Results.GuideResults;
using MediatR;

namespace DreamTravel.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery: IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int id) 
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
