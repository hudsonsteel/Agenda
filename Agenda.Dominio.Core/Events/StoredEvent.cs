using Agenda.Dominio.Core.Interface.Entidades;
using Dapper.Contrib.Extensions;
using System;

namespace Agenda.Dominio.Core.Events
{
    [Table("AgendaTelefonica.dbo.StoredEvent")]
    public class StoredEvent : Event, IEntidade
    {
        public StoredEvent()
        {

        }
        public StoredEvent(Event theEvent, string dados, string usuario)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MensagemTipo = theEvent.MensagemTipo;
            Dados = dados;
            Usuario = usuario;
        }
        public Guid Id { get; private set; }
        public string Dados { get; private set; }
        public string Usuario { get; private set; }
    }
}
