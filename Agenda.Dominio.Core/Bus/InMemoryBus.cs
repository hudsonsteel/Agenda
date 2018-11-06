using Agenda.Dominio.Core.Commands;
using Agenda.Dominio.Core.Events;
using Agenda.Dominio.Core.Interface;
using MediatR;
using System.Threading.Tasks;

namespace Agenda.Dominio.Core.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore ieventStore)
        {
            _mediator = mediator;
            _eventStore = ieventStore;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MensagemTipo.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
