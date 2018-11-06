using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Interfaces.Validacoes.ContatoTelefone;

namespace Agenda.Dominio.Validacoes.ContatoTelefone
{
    public class RemoverContatoTelefoneCommandValidacao : ContatoTelefoneValidacao<ContatoTelefoneCommand>, IRemoverContatoTelefoneComamndValidacao
    {
        public RemoverContatoTelefoneCommandValidacao()
        {
            ValdiarIdContatoTelefone();
        }
    }
}
