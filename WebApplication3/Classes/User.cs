using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darwin.Classes
{
    public class User
    {
        public int id { get; set; }
        public string pseudo { get; set; }
        public string mail { get; set; }
        public string motpasse { get; set; }

        public User(int _id, string _pseudo, string _mail, string _motpasse)
        {
            this.id = _id;
            this.pseudo = _pseudo;
            this.mail = _mail;
            this.motpasse = _motpasse;
        }

        public User(string _pseudo)
        {
            this.pseudo = _pseudo;
        }
    }
}
