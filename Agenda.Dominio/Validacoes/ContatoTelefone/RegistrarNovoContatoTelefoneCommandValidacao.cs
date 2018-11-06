using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Interfaces.Validacoes.Contato;
using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;

namespace Agenda.Dominio.Validacoes.ContatoTelefone
{
    public class RegistrarNovoContatoTelefoneCommandValidacao : ContatoTelefoneValidacao<ContatoTelefoneCommand>, IRegistrarNovoContatoTelefoneCommandValidacao
    {
        public RegistrarNovoContatoTelefoneCommandValidacao()
        {
            ValidarTelefone();
        }
    }
}
