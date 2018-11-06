using Agenda.Dominio.Commands.Contato;

namespace Agenda.Dominio.Validacoes.Contato
{
    public class AtualizarContatoCommandValidacao : ContatoValidacao<ContatoCommand>
    {
        public AtualizarContatoCommandValidacao()
        {
            
            ValidarIdContato();
            ValidarNome();
            ValidarDataCadastro();
            ValidarDataCadastro();
        }
    }
}
