using MediatR;

namespace DreamTravel.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descp { get; set; }
        public string img { get; set; }
    }
}
