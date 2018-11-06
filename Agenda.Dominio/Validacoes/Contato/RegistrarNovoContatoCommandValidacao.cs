using Agenda.Dominio.Commands.Contato;
using Agenda.Dominio.Interfaces.Validacoes.Contato;

namespace Agenda.Dominio.Validacoes.Contato
{
    public class RegistrarNovoContatoCommandValidacao : ContatoValidacao<ContatoCommand>, IRegistrarNovoContatoCommandValidacao
    {
        public RegistrarNovoContatoCommandValidacao()
        {
            ValidarNome();
        }
    }
}
