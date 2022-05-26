using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface INotification_CountRepository
    {
        Notification_Count GetNotificationsCountByUserId(int id);
        Notification_Count UpdateNotificationByNotifi(Notification_Count notifi);
        Notification_Count CreateNotificationCount(Notification_Count notifi);
    }
}
