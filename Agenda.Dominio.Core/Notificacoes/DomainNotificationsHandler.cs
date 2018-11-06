using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Dominio.Core.Notificacoes
{
    public class DomainNotificationsHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notificacoes;
        public DomainNotificationsHandler()
        {
            _notificacoes = new List<DomainNotification>();
        }
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notificacoes.Add(notification);

            return Task.CompletedTask;
        }
        public virtual List<DomainNotification> GetNotificacoes()
        {
            return _notificacoes;
        }
        public  virtual bool TemNotificacoes()
        {
            return GetNotificacoes().Any();
        }
        public void Dispose()
        {
            _notificacoes = new List<DomainNotification>();
        }
    }
}
