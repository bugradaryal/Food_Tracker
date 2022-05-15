using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationService
    {
        Notification GetUsersNotifications(int id);
        Notification CreateNotification(Notification Notification);
        Notification UpdateNotification(Notification Notification);
    }
}
