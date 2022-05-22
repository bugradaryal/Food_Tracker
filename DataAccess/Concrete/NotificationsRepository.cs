using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class NotificationRepository : INotificationRepository
    {
        public Notification CreateNotification(Notification Notification)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Notifications.Add(Notification);
                DbContext.SaveChanges();
                return Notification;
            }
        }
        public List<Notification> GetNotificationsByUserId(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Notifications.Where(x => x.user_id == id ).ToList();
            }
        }
        public void DeleteNotificationsById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletenotifi = DbContext.Notifications.Where(x => x.id == id).FirstOrDefault();
                DbContext.Notifications.Remove(deletenotifi);
                DbContext.SaveChanges();
            }
        }
    }
}

