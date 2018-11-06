using MediatR;
using System;

namespace Agenda.Dominio.Core.Events
{
    public abstract class Event : Mensagem, INotification
    {
        public DateTime DataCadastro { get; private set; }

        protected Event()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
