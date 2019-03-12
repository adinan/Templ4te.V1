using System;
using System.Collections.Generic;
using System.Text;

namespace Templ4te.V1.Domain.Notifications
{
    public class DomainNotification 
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public string Sender { get; private set; }

        public DomainNotification(string key, string value, string sender)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Sender = sender;
        }
    }
}
