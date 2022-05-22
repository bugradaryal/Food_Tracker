using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private INotificationRepository _NotificationRepository;

        public NotificationManager()
        {
            _NotificationRepository = new NotificationRepository();
        }

        public Notification CreateNotification(Notification Notification)
        {
            return _NotificationRepository.CreateNotification(Notification);
        }
        public List<Notification> GetNotificationsByUserId(int id)
        {
            return _NotificationRepository.GetNotificationsByUserId(id);
        }
        public void DeleteNotificationsById(int id)
        {
            _NotificationRepository.DeleteNotificationsById(id);
        }
    }
}
