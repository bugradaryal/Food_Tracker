using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Notification_Count
    {
        public int id { get; set; }
        public int notificationscount { get; set; }
        public int user_id { get; set; }
        public User User { get; set; } 
    }
}
