using Agenda.Dominio.Core.Events;
using System;

namespace Agenda.Dominio.Events.ContatoEmail
{
    public abstract class ContatoEmailEvent : Event
    {
        public ContatoEmailEvent(long idContatoEmail, long idContato, string email, DateTime dtCadastro, DateTime? dtExcluido) : this(idContatoEmail)
        {
            IdContato = idContato;
            Email = email;
            DtCadastro = dtCadastro;
            DtExcluido = dtExcluido;
        }

        private ContatoEmailEvent(long idContato)
        {
            IdContato = idContato;
            AggregateId = idContato;
        }

        public long IdContatoEmail { get; set; }
        public long IdContato { get; set; }
        public string Email { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtExcluido { get; set; }
    }
}
