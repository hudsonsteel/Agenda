using System;

namespace Agenda.Dominio.Events.ContatoTelefone
{
    public class RemovidoContatoTelefoneEvent : ContatoTelefoneEvent
    {
        public RemovidoContatoTelefoneEvent(long idContatoTelefone, long idContato, string telefone, DateTime dtCadastro, DateTime? dtExcluido) : base(idContatoTelefone, idContato, telefone, dtCadastro, dtExcluido)
        {
        }
    }
}
