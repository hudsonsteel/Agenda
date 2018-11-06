using Agenda.Aplicacao.ViewModel;
using Agenda.Dominio.Commands.Contato;
using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Validacoes.Contato;
using Agenda.Dominio.Validacoes.ContatoEmail;
using Agenda.Dominio.Validacoes.ContatoTelefone;
using AutoMapper;
using System.Linq;

namespace Agenda.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContatoViewModel, RegistrarNovoContatoCommand>()
                .ConstructUsing(c =>
                new RegistrarNovoContatoCommand(
                    c.ContatoEmails.Select(x => { return new RegistrarNovoContatoEmailCommand(new RegistrarNovoContatoEmailCommandValidacao(), x.Email); }).ToList()
                    , c.ContatoTelefones.Select(x => { return new RegistrarNovoContatoTelefoneCommand(new RegistrarNovoContatoTelefoneCommandValidacao(), x.Telefone); }).ToList()
                    , new RegistrarNovoContatoCommandValidacao()
                    , c.Nome));

            CreateMap<ContatoTelefoneViewModel, RemoverContatoTelefoneCommand>()
               .ConstructUsing(c =>
               new RemoverContatoTelefoneCommand(new RemoverContatoTelefoneCommandValidacao(), c.IdContatoTelefone));

            CreateMap<ContatoEmailViewModel, RemoverContatoEmailCommand>()
                          .ConstructUsing(c =>
                          new RemoverContatoEmailCommand(new RemoverContatoEmailCommandValidacao(), c.IdContatoEmail));

        }
    }
}
