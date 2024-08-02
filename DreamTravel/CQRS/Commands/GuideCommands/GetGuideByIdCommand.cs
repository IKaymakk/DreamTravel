using DreamTravel.CQRS.Results.GuideResults;
using MediatR;

namespace DreamTravel.CQRS.Commands.GuideCommands
{
    public class GetGuideByIdCommand : IRequest<GetGuideByIdQueryResult>
    {

    }
}
