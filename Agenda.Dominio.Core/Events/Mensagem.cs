using MediatR;
using System;

namespace Agenda.Dominio.Core.Events
{
    public abstract class Mensagem : IRequest
    {
        public string MensagemTipo { get; protected set; }
        public long AggregateId { get; protected set; }

        protected Mensagem()
        {
            MensagemTipo = GetType().Name;
        }
    }
}