using System;
using System.Collections.Generic;
using System.Text;

namespace Templ4te.V1.Domain.Notifications
{
    public interface IDomainNotificationList
    {
        List<DomainNotification> GetNotifications();
        void Add(string mensagem, string sender, string key = null);
        bool HasNotifications();
    }
}
