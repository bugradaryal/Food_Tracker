using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Fridge
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }

        //ref
        public User User { get; set; }
        public ICollection<My_Food> My_Food { get; set; }
    }
}
