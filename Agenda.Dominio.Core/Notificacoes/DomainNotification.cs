using Agenda.Dominio.Core.Events;
using System;

namespace Agenda.Dominio.Core.Notificacoes
{
    public class DomainNotification : Event
    {
        public DomainNotification(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
            Versao = 1;
            DomainNotificationId = Guid.NewGuid();
        }

        public Guid DomainNotificationId { get; private set; }
        public string Chave { get;private set; }
        public string Valor { get;private set; }
        public int Versao { get; private set; }

    }
}