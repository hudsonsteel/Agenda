using Agenda.Dominio.Core.Events;
using Agenda.Dominio.Core.Interface;
using Agenda.Dominio.Interfaces.Repositorio;
using Newtonsoft.Json;

namespace Agenda.Infra.Repositorio.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IStoredEventRepositorio _eventStoreRepository;

        public SqlEventStore(IStoredEventRepositorio eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Administrador");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
