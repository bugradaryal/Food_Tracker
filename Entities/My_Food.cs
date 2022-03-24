using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class My_Food
    {
        public int id { get; set; }
        public int yemek_no { get; set; }
        public Fridge Fridge { get; set; } //bir ilişki
        public Food Food { get; set; }  //bir ilişki
    }
}
