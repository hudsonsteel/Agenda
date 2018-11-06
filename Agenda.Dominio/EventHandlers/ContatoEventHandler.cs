using System.Threading;
using System.Threading.Tasks;
using Agenda.Dominio.Events.Contato;
using MediatR;

namespace Agenda.Dominio.EventHandlers
{
    public class ContatoEventHandler :
        INotificationHandler<RegistradoContatoEvent>
        , INotificationHandler<AtualizadoContatoEvent>
        , INotificationHandler<RemovidoContatoEvent>
    {
        public ContatoEventHandler()
        {
        }

        public Task Handle(RemovidoContatoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AtualizadoContatoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RegistradoContatoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
