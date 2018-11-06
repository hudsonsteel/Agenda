using Agenda.Aplicacao.Interfaces;
using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Interfaces.Repositorio;
using AutoMapper;

namespace Agenda.Aplicacao.Services
{
    public class ContatoTelefoneAppService : AppServiceBase, IContatoTelefoneAppService
    {
        private readonly IContatoTelefoneRepositorio contatoTelefoneRepositorio;
        public ContatoTelefoneAppService(IMapper mapper, IMediatorHandler bus, IContatoTelefoneRepositorio  contatoTelefoneRepositorio) : base(mapper, bus)
        {
            this.contatoTelefoneRepositorio = contatoTelefoneRepositorio;
        }

        public void Remover(ContatoTelefoneViewModel contatoTelefoneViewModel)
        {
            var commandDeletar = _mapper.Map<RemoverContatoTelefoneCommand>(contatoTelefoneViewModel);
            _bus.SendCommand(commandDeletar);
        }
    }
}
