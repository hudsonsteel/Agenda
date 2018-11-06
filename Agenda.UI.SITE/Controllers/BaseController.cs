using Agenda.Dominio.Core.Notificacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.UI.SITE.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationsHandler _notifications;
        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationsHandler)notifications;
        }
        public bool IsValidOperation()
        {
            return (!_notifications.TemNotificacoes());
        }
    }
}
