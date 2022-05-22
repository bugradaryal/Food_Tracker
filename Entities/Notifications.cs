using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Notification
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string bildirim { get; set; }

        public User User { get; set; }
    }
}
