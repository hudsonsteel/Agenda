using System;

namespace Agenda.Dominio.Events.ContatoEmail
{
    public class RegistradoContatoEmailEvent : ContatoEmailEvent
    {
        public RegistradoContatoEmailEvent(long idContatoEmail, long idContato, string email, DateTime dtCadastro, DateTime? dtExcluido) : base(idContatoEmail, idContato, email, dtCadastro, dtExcluido)
        {
        }
    }
}
