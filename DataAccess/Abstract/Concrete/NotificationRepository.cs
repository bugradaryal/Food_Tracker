using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class NotificationRepository : INotificationRepository
    {
        public Notification GetUsersNotifications(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Notification.FirstOrDefault(x => x.user_id == id);
            }
        }
        public Notification CreateNotification(Notification Notification)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Notification.Add(Notification);
                DbContext.SaveChanges();
                return Notification;
            }
        }
        public Notification UpdateNotification(Notification Notification)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Notification.Update(Notification);
                DbContext.SaveChanges();
                return Notification;
            }
        }
    }
}
