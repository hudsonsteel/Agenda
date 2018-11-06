using Agenda.Dominio.Core.Bus;
using AutoMapper;

namespace Agenda.Aplicacao.Services
{
    public abstract class AppServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly IMediatorHandler _bus;

        protected AppServiceBase(IMapper mapper, IMediatorHandler bus)
        {
            _mapper = mapper;
            _bus = bus;
        }
    }
}
