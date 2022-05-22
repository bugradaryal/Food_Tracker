using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationTypeService
    {
        NotificationType GetUsersNotification(int id);
        NotificationType CreateNotification(NotificationType Notification);
        NotificationType UpdateNotification(NotificationType Notification);
    }
}
