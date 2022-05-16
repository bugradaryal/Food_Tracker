using Entities;
using System.Collections.Generic;

namespace Web.API.Models
{
    public class ViewModels
    {
        public User User { get; set; }
        public IList<Fridge> Fridge { get; set; }

        public Notification Notification { get; set; }

        public IList<Food> Food { get; set; }

        public int id { get; set; }
        public int food_id { get; set; }
        public string name { get; set; }
    }
}
