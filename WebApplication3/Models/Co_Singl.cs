using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Darwin.Models
{
    public class Co_Singl
    {
        private static Co_Singl Instance;
        private MySqlConnection connexion;

        private Co_Singl()
        {
            string Costring = @"server=localhost;userid=Chat;password=chatuser;database=chat_projet";

            this.connexion =  new MySqlConnection(Costring);
            this.connexion.Open();
        }

        public static Co_Singl getInstance()
        {
            if(Instance == null)
            {
                Instance = new Co_Singl();
            }

            return Instance;
        }

        public MySqlConnection getConnexion()
        {
            return this.connexion;
        }
    }
}