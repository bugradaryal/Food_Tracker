using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Cinsiyet { get; set; }

        //ref
        public ICollection<Fridge> Fridge { get; set; }
        public ICollection<User_article> User_article { get; set; }
        public Notification Notification { get; set; }
    }
}
