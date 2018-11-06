using System;

namespace Agenda.Dominio.Events.ContatoTelefone
{
    public class RegistradoContatoTelefoneEvent : ContatoTelefoneEvent
    {
        public RegistradoContatoTelefoneEvent(long idContatoTelefone, long idContato, string telefone, DateTime dtCadastro, DateTime? dtExcluido) : base(idContatoTelefone, idContato, telefone, dtCadastro, dtExcluido)
        {
        }
    }
}
