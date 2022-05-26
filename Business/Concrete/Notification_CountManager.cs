using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class Notification_CountManager : INotification_CountService
    {
        private INotification_CountRepository notification_CountRepository;

        public Notification_CountManager()
        {
            notification_CountRepository = new Notification_CountRepository();
        }

        public Notification_Count GetNotificationsCountByUserId(int id)
        {
            return notification_CountRepository.GetNotificationsCountByUserId(id);
        }
        public Notification_Count UpdateNotificationByNotifi(Notification_Count notifi)
        {
            return notification_CountRepository.UpdateNotificationByNotifi(notifi);
        }
        public Notification_Count CreateNotificationCount(Notification_Count notifi)
        {
            return notification_CountRepository.CreateNotificationCount(notifi);
        }
    }
}
