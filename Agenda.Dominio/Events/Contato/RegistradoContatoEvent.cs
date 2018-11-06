using Agenda.Dominio.Core.Events;
using System;

namespace Agenda.Dominio.Events.Contato
{
    public class RegistradoContatoEvent : ContatoEvent
    {
        public RegistradoContatoEvent(long idContato, string nome, DateTime dtCadastro, DateTime? dtExcluido) : base(idContato, nome, dtCadastro, dtExcluido)
        {
        }
    }
}
