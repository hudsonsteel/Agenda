using System;
using Agenda.Dominio.Core.Events;

namespace Agenda.Dominio.Events.Contato
{
    public class AtualizadoContatoEvent : ContatoEvent
    {
        public AtualizadoContatoEvent(long idContato, string nome, DateTime dtCadastro, DateTime? dtExcluido) : base(idContato, nome, dtCadastro, dtExcluido)
        {
        }
    }
}
