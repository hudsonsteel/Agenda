using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Interfaces.Validacoes.ContatoEmail;

namespace Agenda.Dominio.Validacoes.ContatoEmail
{
    public class RemoverContatoEmailCommandValidacao : ContatoEmailValidacao<ContatoEmailCommand>, IRemoverContatoEmailCommandValidacao
    {
        public RemoverContatoEmailCommandValidacao()
        {
            ValdiarIdContatoTelefone();
        }
    }
}
