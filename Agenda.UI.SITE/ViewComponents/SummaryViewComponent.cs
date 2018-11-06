using Agenda.Dominio.Core.Notificacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agenda.UI.SITE.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationsHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationsHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult((_notifications.GetNotificacoes()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Valor));

            return View();
        }
    }
}
