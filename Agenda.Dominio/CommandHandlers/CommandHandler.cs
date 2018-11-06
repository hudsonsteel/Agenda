using Agenda.Dominio.Core.Bus;
using Agenda.Dominio.Core.Commands;
using Agenda.Dominio.Core.Notificacoes;
using Agenda.Dominio.Interfaces.Uow;
using MediatR;

namespace Agenda.Dominio.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnityOfWork _uow;
        private readonly DomainNotificationsHandler _notificacao;
        protected IMediatorHandler _bus { get; private set; }

        public CommandHandler(IUnityOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notificacao)
        {
            _uow = uow;
            _notificacao = (DomainNotificationsHandler)notificacao;
            _bus = bus;
        }
        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult?.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MensagemTipo, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notificacao.TemNotificacoes()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um problema ao executar os dados."));
            return false;
        }
    }
}
