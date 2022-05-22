using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationService
    {
        Notification CreateNotification(Notification Notification);
        List<Notification> GetNotificationsByUserId(int id);
        void DeleteNotificationsById(int id);
    }
}

