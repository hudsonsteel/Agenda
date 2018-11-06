using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Entidades;
using AutoMapper;

namespace Agenda.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contato, ContatoViewModel>();
        }
    }
}
