using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Commands.DestinationCommands;

namespace DreamTravel.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.ID);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
