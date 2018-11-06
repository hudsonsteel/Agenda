using System;

namespace Agenda.Dominio.Events.ContatoEmail
{
    public class RemovidoContatoEmailEvent : ContatoEmailEvent
    {
        public RemovidoContatoEmailEvent(long idContatoEmail, long idContato, string email, DateTime dtCadastro, DateTime? dtExcluido) : base(idContatoEmail, idContato, email, dtCadastro, dtExcluido)
        {
        }
    }
}
