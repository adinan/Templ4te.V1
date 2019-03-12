using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Templ4te.V1.Domain.Notifications
{
    public class DomainNotificationList: IDomainNotificationList
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationList()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Add(string mensagem, string sender, string chave = null)
        {
            //var sender = GetType().Name;
            var notification = new DomainNotification(chave, mensagem, sender);
            _notifications.Add(notification);
            Debug.WriteLine($"Erro: {mensagem} - {chave}");
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
