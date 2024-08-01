using DataAccessLayer.Concrete;
using DreamTravel.CQRS.Commands.DestinationCommands;

namespace DreamTravel.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.destinationid);
            values.City = command.city;
            values.DayNight = command.duration;
            values.Price = command.price;
            _context.SaveChanges();
        }
    }
}
