using System.Threading;
using System.Threading.Tasks;
using Agenda.Dominio.Commands.ContatoEmail;
using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Core.Notificacoes;
using Agenda.Dominio.Events.ContatoEmail;
using Agenda.Dominio.Interfaces.Repositorio;
using Agenda.Dominio.Interfaces.Uow;
using MediatR;

namespace Agenda.Dominio.CommandHandlers
{
    public class ContatoEmailCommandHandler :
        CommandHandler
        , IRequestHandler<RemoverContatoEmailCommand>
    {
        private readonly IContatoEmailRespositorio contatoEmailRespositorio;
        public ContatoEmailCommandHandler(IContatoEmailRespositorio contatoEmailRespositorio, IUnityOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notificacao) : base(uow, bus, notificacao)
        {
            this.contatoEmailRespositorio = contatoEmailRespositorio;
        }

        public Task Handle(RemoverContatoEmailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            if (!contatoEmailRespositorio.ExistEmailCadastrado(request.IdContatoEmail))
            {
                _bus.RaiseEvent(new DomainNotification(request.MensagemTipo, "Não foi possivel encontrar este email."));
                return Task.CompletedTask;
            }

            var contatoEmail = contatoEmailRespositorio.Find(request.IdContatoEmail);

            contatoEmailRespositorio.Remove(contatoEmail);

            //Busco de novo para pegar a data DtExcluido atualizado.
            contatoEmail = contatoEmailRespositorio.Find(request.IdContatoEmail);

            if (Commit())
            {
                _bus.RaiseEvent(new RemovidoContatoEmailEvent(contatoEmail.IdContatoEmail
                    , contatoEmail.IdContato
                    , contatoEmail.Email
                    , contatoEmail.DtCadastro
                    , contatoEmail.DtExcluido));
            }

            return Task.CompletedTask;
        }
    }
}
