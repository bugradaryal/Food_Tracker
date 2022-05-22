using Entities;
using System.Collections.Generic;

namespace Web.API.Models
{
    public class ViewModels
    {
        public User User { get; set; }
        public IList<Fridge> Fridge { get; set; }

        public NotificationType NotificationType { get; set; }

        public IList<My_Food> My_Food { get; set; }

        public IList<Food> Food { get; set; }

        public IList<User_article> User_article { get; set; }

        public int User_article_id { get; set; }
        public int Notification_id { get; set; }
        public int Fridge_id { get; set; }
        public int Myfood_id { get; set; }
        public int Food_id { get; set; }
        public string name { get; set; }
    }
}
