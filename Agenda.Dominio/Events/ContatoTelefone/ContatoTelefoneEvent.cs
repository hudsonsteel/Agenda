using Agenda.Dominio.Core.Events;
using System;

namespace Agenda.Dominio.Events.ContatoTelefone
{
    public class ContatoTelefoneEvent : Event
    {
        public ContatoTelefoneEvent(long idContatoTelefone, long idContato, string telefone, DateTime dtCadastro, DateTime? dtExcluido)
        {
            AggregateId = idContatoTelefone;

            IdContatoTelefone = idContatoTelefone;
            IdContato = idContato;
            Telefone = telefone;
            DtCadastro = dtCadastro;
            DtExcluido = dtExcluido;
        }

        public long IdContatoTelefone { get; private set; }
        public long IdContato { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DtCadastro { get; private set; }
        public DateTime? DtExcluido { get; private set; }
    }
}
