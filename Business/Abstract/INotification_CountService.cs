using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotification_CountService
    {
        Notification_Count GetNotificationsCountByUserId(int id);
        Notification_Count UpdateNotificationByNotifi(Notification_Count notifi);
        Notification_Count CreateNotificationCount(Notification_Count notifi);
    }
}
