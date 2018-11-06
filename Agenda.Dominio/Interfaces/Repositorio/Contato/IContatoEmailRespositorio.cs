using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.ICrud;

namespace Agenda.Dominio.Interfaces.Repositorio
{
    public interface IContatoEmailRespositorio : IAdd<ContatoEmail>, IRemove<ContatoEmail>, IFind<ContatoEmail>
    {
        bool ExistEmailCadastrado(long idContatoEmail);
    }
}
