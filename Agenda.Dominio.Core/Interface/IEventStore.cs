using Agenda.Dominio.Core.Events;

namespace Agenda.Dominio.Core.Interface
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
