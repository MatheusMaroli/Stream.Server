using System.Collections.Generic;
using System.Linq;

namespace Stream.Server.Domain.CommandsBehaviors
{
    public abstract class NotificationValidatorContext
	{
		private readonly List<string> _notifications;
		public IReadOnlyCollection<string> Notifications => _notifications;
		public bool IsInvalid => _notifications.Any();

		public NotificationValidatorContext()
		{
			_notifications = new List<string>();
		}

		public void AddNotification(string message)
		{
			_notifications.Add(message);
		}

		public void AddNotifications(IReadOnlyCollection<string> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(IList<string> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ICollection<string> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public abstract void Validate();
	}
}
