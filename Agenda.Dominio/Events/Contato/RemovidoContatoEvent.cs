using Agenda.Dominio.Core.Events;

namespace Agenda.Dominio.Events.Contato
{
    public class RemovidoContatoEvent : ContatoEvent
    {
        public RemovidoContatoEvent(long idContato) : base(idContato)
        {
        }
    }
}
