using Agenda.Dominio.Core.Events;
using System;

namespace Agenda.Dominio.Events.Contato
{
    public abstract class ContatoEvent : Event
    {
        protected ContatoEvent(long idContato)
        {
            this.IdContato = idContato;
            AggregateId = idContato;
        }
        protected ContatoEvent(long idContato, string nome, DateTime dtCadastro, DateTime? dtExcluido)
        {
            this.IdContato = idContato;
            this.Nome = nome;
            this.DtCadastro = dtCadastro;
            this.DtExcluido = dtExcluido;
            AggregateId = idContato;
        }

        public long IdContato { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DtCadastro { get; protected set; }
        public DateTime? DtExcluido { get; protected set; }
    }
}
