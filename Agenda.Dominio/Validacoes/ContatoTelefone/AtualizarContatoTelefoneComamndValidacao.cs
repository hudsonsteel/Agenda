using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;

namespace Agenda.Dominio.Validacoes.ContatoTelefone
{
    public class AtualizarContatoTelefoneComamndValidacao : ContatoTelefoneValidacao<ContatoTelefoneCommand>, IAtualizarContatoTelefoneComamndValidacao
    {
        public AtualizarContatoTelefoneComamndValidacao()
        {
            ValidarTelefone();
        }
    }
}
