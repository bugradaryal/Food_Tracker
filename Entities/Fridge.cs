using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Fridge
    {
        public int id { get; set; }
        public int buzdolabı_id { get; set; }
        public User User { get; set; }  //bir ilişki
        public ICollection<My_Food> My_Food { get; set; } //ÇOK ilişki
    }
}
