using System.Threading;
using System.Threading.Tasks;
using Agenda.Dominio.Commands.ContatoTelefone;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Core.Notificacoes;
using Agenda.Dominio.Events.ContatoTelefone;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using MediatR;

namespace Agenda.Dominio.CommandHandlers
{
    public class ContatoTelefoneCommandHandler :
        CommandHandler
        , IRequestHandler<RemoverContatoTelefoneCommand>
    {
        private readonly IContatoTelefoneRepositorio contatoTelefoneRepositorio;
        public ContatoTelefoneCommandHandler(IContatoTelefoneRepositorio contatoTelefoneRepositorio, IUnityOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notificacao) : base(uow, bus, notificacao)
        {
            this.contatoTelefoneRepositorio = contatoTelefoneRepositorio;
        }

        public Task Handle(RemoverContatoTelefoneCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            if (!contatoTelefoneRepositorio.ExistTelefoneCadastrado(request.IdContatoTelefone))
            {
                _bus.RaiseEvent(new DomainNotification(request.MensagemTipo, "Não foi possivel encontrar este telefone."));
                return Task.CompletedTask;
            }

            var contatoTelefone = contatoTelefoneRepositorio.Find(request.IdContatoTelefone);

            contatoTelefoneRepositorio.Remove(contatoTelefone);

            //Busco de novo para pegar a data DtExcluido atualizado.
            contatoTelefone = contatoTelefoneRepositorio.Find(request.IdContatoTelefone);

            if (Commit())
            {
                _bus.RaiseEvent(new RemovidoContatoTelefoneEvent(contatoTelefone.IdContatoTelefone
                    , contatoTelefone.IdContato
                    , contatoTelefone.Telefone
                    ,contatoTelefone.DtCadastro
                    ,contatoTelefone.DtExcluido));
            }

            return Task.CompletedTask;
        }
    }
}
