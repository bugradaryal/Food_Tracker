using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private INotificationRepository _notificationRepository;

        public NotificationManager()
        {
            _notificationRepository = new NotificationRepository();
        }
        public Notification GetUsersNotifications(int id)
        {
           return _notificationRepository.GetUsersNotifications(id);
        }
        public Notification CreateNotification(Notification Notification)
        {
            return _notificationRepository.CreateNotification(Notification);
        }
        public Notification UpdateNotification(Notification Notification)
        {
            return _notificationRepository.UpdateNotification(Notification);
        }
    }
}
