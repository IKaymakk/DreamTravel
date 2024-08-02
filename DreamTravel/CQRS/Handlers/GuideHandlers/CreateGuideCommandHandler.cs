using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Commands.GuideCommands;
using EntityLayer.Concrete;
using MediatR;

namespace DreamTravel.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Description = request.descp,
                Name = request.name,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
