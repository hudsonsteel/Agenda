using Agenda.Dominio.Commands.Contato;

namespace Agenda.Dominio.Validacoes.Contato
{
    public class RemoveContatoCommandValidacao : ContatoValidacao<ContatoCommand>
    {
        public RemoveContatoCommandValidacao()
        {
            ValidarIdContato();
        }
    }
}
