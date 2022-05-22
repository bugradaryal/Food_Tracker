using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface INotificationRepository
    {
        Notification CreateNotification(Notification Notification);
        List<Notification> GetNotificationsByUserId(int id);
        void DeleteNotificationsById(int id);
    }
}