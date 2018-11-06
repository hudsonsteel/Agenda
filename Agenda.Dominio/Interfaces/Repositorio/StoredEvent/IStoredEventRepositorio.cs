using Agenda.Dominio.Core.Events;
using Agenda.Dominio.Interfaces.ICrud;
using System.Collections.Generic;

namespace Agenda.Dominio.Interfaces.Repositorio
{
    public interface IStoredEventRepositorio : IAll<StoredEvent>, IAdd<StoredEvent>
    {
        void Store(StoredEvent theEvent);

    }
}
