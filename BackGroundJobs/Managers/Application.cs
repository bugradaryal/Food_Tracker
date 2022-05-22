using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using Entities;

namespace BackGroundJobs.Managers
{
    public class Application
    {
        private INotificationService _notificationService;
        public Application()
        {
            _notificationService = new NotificationManager();
        }

        public void sendApplicationNotification(User user, Food myfood)
        {
            string bildirim = myfood.yemek_ismi + " Adlı yemeğinizin bozulmasına son 24 saat kaldı.";
            _notificationService.CreateNotification(new Notification { user_id = user.id, bildirim = bildirim});           
        }
    }
}
