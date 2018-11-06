using Agenda.Aplicacao.AutoMapper;
using Agenda.Aplicacao.Interfaces;
using Agenda.Aplicacao.Services;
using Agenda.Dominio.CommandHandlers;
using Agenda.Dominio.Commands.Contato;
using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Core.Interface;
using Agenda.Dominio.Core.Notificacoes;
using Agenda.Dominio.EventHandlers;
using Agenda.Dominio.Events.Contato;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using Agenda.Infra.Interfaces.Servico;
using Agenda.Infra.Repositorio;
using Agenda.Infra.Repositorio.Contato;
using Agenda.Infra.Repositorio.EventSourcing;
using Agenda.Infra.Servico;
using Agenda.Infra.Uow;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Dominio Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Agenda Aplicação
            services.AddScoped<IContatoAppService, ContatoAppService>();
            services.AddScoped<IContatoTelefoneAppService, ContatoTelefoneAppService>();
            services.AddScoped<IContatoEmailAppService, ContatoEmailAppService>();

            //Agenda Dominio Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationsHandler>();
            services.AddScoped<INotificationHandler<AtualizadoContatoEvent>, ContatoEventHandler>();
            services.AddScoped<INotificationHandler<RemovidoContatoEvent>, ContatoEventHandler>();
            services.AddScoped<INotificationHandler<RegistradoContatoEvent>, ContatoEventHandler>();

            //Agenda Dominio
            services.AddScoped<IRequestHandler<RegistrarNovoContatoCommand>, ContatoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverContatoTelefoneCommand>, ContatoTelefoneCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverContatoEmailCommand>, ContatoEmailCommandHandler>();

            //Infra Data Sourcing
            services.AddScoped<IEventStore, SqlEventStore>();

            services.AddSingleton<IMapper>(sp => AutoMapperConfig.RegisterMappings().CreateMapper());

            //Agenda Infra
            services.AddScoped<ISqlServerVerifyServico, SqlServerVerifyServico>();
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

            services.AddScoped<IContatoEmailRespositorio, ContatoEmailRepositorio>();
            services.AddScoped<IContatoTelefoneRepositorio, ContatoTelefoneRepositorio>();


            services.AddScoped<IStoredEventRepositorio, StoredEventRepositorio>();
            services.AddScoped<IUnityOfWork, UnitOfWork>();
        }
    }
}
