using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Darwin.Models.Connexion
{
    public class UserConnexion
    {
        private static MySqlConnection connexion = Models.Co_Singl.getInstance().getConnexion();

        public static List<Classes.User> GetAll()
        {
            List<Classes.User> result = new List<Classes.User>();
            string Query = @"Select * FROM `users`";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);

            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Classes.User user = new Classes.User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    result.Add(user);
                }
            }
            cmd = null;
            return result;
        }

        public static Classes.User GetOne(string Mail)
        {
            string Query = @"SELECT * FROM `users` WHERE `email` = " + Mail;
            MySqlCommand cmd = new MySqlCommand(Query, connexion);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    Classes.User user = new Classes.User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    cmd = null;
                    return user;
                }
            }
            catch(MySqlException e)
            {
                return new Classes.User(e.Message);
            }
        }

        public static void Insert(string Pseudo, string Mail, string MotPasse)
        {
            string Query = @"INSERT INTO `users` (`pseudo`, `email`, `motpasse`) VALUES ('" + Pseudo + "', '" + Mail + "', '" + MotPasse + "')";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }

        public static void Update(int Id, string Pseudo, string Mail, string MotPasse)
        {
            string Query = @"UPDATE `users` SET `pseudo` = '"+ Pseudo +"', `email` = '"+ Mail +"', `motpasse` = '"+ MotPasse +"' WHERE `users`.`code_user` = " + Id + ";";
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }

        public static void Delete(int Id)
        {
            string Query = @"DELETE FROM `users` WHERE `users`.`code_user` = " + Id;
            MySqlCommand cmd = new MySqlCommand(Query, connexion);
            cmd.ExecuteNonQuery();
            cmd = null;
        }
    }
}
