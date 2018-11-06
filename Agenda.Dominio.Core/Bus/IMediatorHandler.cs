using Agenda.Dominio.Core.Commands;
using Agenda.Dominio.Core.Events;
using System.Threading.Tasks;

namespace Agenda.Dominio.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
