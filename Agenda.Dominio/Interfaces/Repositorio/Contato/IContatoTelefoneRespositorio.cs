using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.ICrud;

namespace Agenda.Dominio.Interfaces.Repositorio
{
    public interface IContatoTelefoneRepositorio : IAdd<ContatoTelefone>,  IRemove<ContatoTelefone>, IFind<ContatoTelefone>
    {
        bool ExistTelefoneCadastrado(long idContatoTelefone);
    }
}
