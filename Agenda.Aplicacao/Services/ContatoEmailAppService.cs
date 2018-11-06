using Agenda.Aplicacao.Interfaces;
using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Interfaces.Repositorio;
using AutoMapper;

namespace Agenda.Aplicacao.Services
{
    public class ContatoEmailAppService : AppServiceBase, IContatoEmailAppService
    {
        private readonly IContatoEmailRespositorio contatoEmailRespositorio;
        public ContatoEmailAppService(IContatoEmailRespositorio contatoEmailRespositorio,IMapper mapper, IMediatorHandler bus) : base(mapper, bus)
        {
            this.contatoEmailRespositorio = contatoEmailRespositorio;
        }

        public void Remover(ContatoEmailViewModel contatoEmailViewModel)
        {
            var commandDeletar = _mapper.Map<RemoverContatoEmailCommand>(contatoEmailViewModel);
            _bus.SendCommand(commandDeletar);
        }
    }
}
