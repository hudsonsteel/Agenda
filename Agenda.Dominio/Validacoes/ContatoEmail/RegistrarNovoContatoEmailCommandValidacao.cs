using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Interfaces.Validacoes.Contato;

namespace Agenda.Dominio.Validacoes.ContatoEmail
{
    public class RegistrarNovoContatoEmailCommandValidacao : ContatoEmailValidacao<ContatoEmailCommand>, IRegistrarNovoContatoEmailCommandValidacao
    {
        public RegistrarNovoContatoEmailCommandValidacao()
        {
            ValidarEmail();
        }
    }
}
