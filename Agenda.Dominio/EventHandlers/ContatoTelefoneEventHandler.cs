using System.Threading;
using System.Threading.Tasks;
using Agenda.Dominio.Events.ContatoTelefone;
using MediatR;

namespace Agenda.Dominio.EventHandlers
{
    public class ContatoTelefoneEventHandler : INotificationHandler<RemovidoContatoTelefoneEvent>
    {
        public Task Handle(RemovidoContatoTelefoneEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
