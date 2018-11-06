using Agenda.Aplicacao.ViewModel;
using System.Collections.Generic;

namespace Agenda.Aplicacao.Interfaces
{
    public interface IContatoAppService
    {
        void Registrar(ContatoViewModel contatoViewModel);
        IEnumerable<ContatoViewModel> GetAll();
        IEnumerable<ContatoViewModel> GetAllAtivos();
        ContatoViewModel GetById(long id);
        void Update(ContatoViewModel contatoViewModel);
    }
}
