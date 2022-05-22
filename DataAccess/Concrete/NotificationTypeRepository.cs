using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class NotificationTypeRepository : INotificationTypeRepository
    {
        public NotificationType GetUsersNotification(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.NotificationType.FirstOrDefault(x => x.user_id == id);
            }
        }
        public NotificationType CreateNotification(NotificationType Notification)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.NotificationType.Add(Notification);
                DbContext.SaveChanges();
                return Notification;
            }
        }
        public NotificationType UpdateNotification(NotificationType Notification)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.NotificationType.Update(Notification);
                DbContext.SaveChanges();
                return Notification;
            }
        }
    }
}
