using Agenda.Aplicacao.Interfaces;
using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Commands.Contato;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.Repositorio;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Aplicacao.Services
{
    public class ContatoAppService : AppServiceBase, IContatoAppService
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoAppService(IMapper mapper, IContatoRepositorio contatoRepositorio, IMediatorHandler bus) : base(mapper, bus)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IEnumerable<ContatoViewModel> GetAll()
        {
            return _mapper.Map<List<Contato>, List<ContatoViewModel>>(_contatoRepositorio.GetAll().ToList());
        }

        public IEnumerable<ContatoViewModel> GetAllAtivos()
        {
            return _mapper.Map<List<Contato>, List<ContatoViewModel>>(_contatoRepositorio.GetAllAtivos().ToList());
        }

        public ContatoViewModel GetById(long id)
        {
            return _mapper.Map<ContatoViewModel>(_contatoRepositorio.Find(id));
        }

        public void Registrar(ContatoViewModel contatoViewModel)
        {
            var regitrarCommand = _mapper.Map<RegistrarNovoContatoCommand>(contatoViewModel);
            _bus.SendCommand(regitrarCommand);
        }

        public void Update(ContatoViewModel contatoViewModel)
        {
            var atualizarCommand = _mapper.Map<RegistrarNovoContatoCommand>(contatoViewModel);
            _bus.SendCommand(atualizarCommand);
        }

        //public IList<CustomerHistoryData> GetAllHistory(Guid id)
        //{
        //    return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        //}
    }
}
