using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Darwin.Classes
{
    public static class Log
    {
        private const string path = @"/Log/log.log";
        private static MySqlConnection connexion = Models.Co_Singl.getInstance().getConnexion();

        public static void Infolog(string message)
        {
            string Query = @"INSERT INTO `Log` (`Severité`, `Heure`, `Message`) VALUES ('Info', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', '"+ message +"')";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }
        public static void Warnlog(string message)
        {
            string Query = @"INSERT INTO `Log` (`Severité`, `Heure`, `Message`) VALUES ('Warn', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', '"+ message +"')";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }
        public static void Errorlog(string message)
        {
            string Query = @"INSERT INTO `Log` (`Severité`, `Heure`, `Message`) VALUES ('Error', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', '"+ message +"')";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }
    }
}
