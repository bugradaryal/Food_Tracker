using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface INotificationTypeRepository
    {
        NotificationType GetUsersNotification(int id);
        NotificationType CreateNotification(NotificationType Notification);
        NotificationType UpdateNotification(NotificationType Notification);
    }
}
