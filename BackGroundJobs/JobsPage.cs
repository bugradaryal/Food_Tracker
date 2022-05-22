using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Business.Abstract;
using Business.Concrete;
using BackGroundJobs.Managers;

namespace BackGroundJobs
{
    public class JobsPage
    {
        private INotificationTypeService _notificationTypeService;
        public JobsPage()
        {
            _notificationTypeService = new NotificationTypeManager();
        }


        public void MainJob(User user, Food myfood)
        {
            var notifi = _notificationTypeService.GetUsersNotification(user.id);
            
            if(notifi.tercih_eposta == true)
            {
                Email.SendEmail(user,myfood);
            }
            if(notifi.tercih_uygulama == true)
            {
                Application app = new Application();
                app.sendApplicationNotification(user,myfood);
            }
            if(notifi.tercih_sms == true)
            {
                Sms sms = new Sms();
                sms.smsbody(user,myfood);
            }
        }
    }
}
