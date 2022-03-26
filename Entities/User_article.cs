using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User_article
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string date { get; set; }  
        public string text { get; set; }

        //ref
        public User User { get; set; }
    }
}
