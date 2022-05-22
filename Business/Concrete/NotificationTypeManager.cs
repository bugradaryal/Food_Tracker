using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class NotificationTypeManager : INotificationTypeService
    {
        private INotificationTypeRepository _notificationTypeRepository;

        public NotificationTypeManager()
        {
            _notificationTypeRepository = new NotificationTypeRepository();
        }
        public NotificationType GetUsersNotification(int id)
        {
           return _notificationTypeRepository.GetUsersNotification(id);
        }
        public NotificationType CreateNotification(NotificationType Notification)
        {
            return _notificationTypeRepository.CreateNotification(Notification);
        }
        public NotificationType UpdateNotification(NotificationType Notification)
        {
            return _notificationTypeRepository.UpdateNotification(Notification);
        }
    }
}
