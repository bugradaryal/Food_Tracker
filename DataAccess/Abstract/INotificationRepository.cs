using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface INotificationRepository
    {
        Notification GetUsersNotifications(int id);
        Notification CreateNotification(Notification Notification);
        Notification UpdateNotification(Notification Notification);
    }
}
