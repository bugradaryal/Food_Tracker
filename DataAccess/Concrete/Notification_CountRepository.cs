using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class Notification_CountRepository : INotification_CountRepository
    {
        public Notification_Count GetNotificationsCountByUserId(int id)
        {
            using (var DbContext = new DataDbContext())
            {
               return DbContext.Notification_Counts.Where(x => x.user_id == id).FirstOrDefault();
            }
        }
        public Notification_Count UpdateNotificationByNotifi(Notification_Count notifi)
        {
            using (var DbContext = new DataDbContext())
            {
                notifi.id = GetNotificationsCountByUserId(notifi.user_id).id;
                DbContext.Notification_Counts.Update(notifi);
                DbContext.SaveChanges();
                return notifi;
            }
        }
        public Notification_Count CreateNotificationCount(Notification_Count notifi)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Notification_Counts.Add(notifi);
                DbContext.SaveChanges();
                return notifi;
            }
        }
    }
}

