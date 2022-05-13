using Entities;
using System.Collections.Generic;

namespace Web.API.Models
{
    public class ViewModels
    {
        public User User { get; set; }
        public IList<Fridge> Fridge { get; set; }

        public IList<My_Food> My_Foods { get; set; } 

        public int id { get; set; }
        public string name { get; set; }
    }
}
