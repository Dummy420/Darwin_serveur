using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Darwin.Models
{
    public static class MasterConnexion
    {
        private static MySqlConnection connexion = Models.Co_Singl.getInstance().getConnexion();

        public static List<Dictionary<string, string>> SelectAll(string Table)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            string Query = @"Select * FROM `" + Table + "`";

            MySqlCommand cmd = new MySqlCommand(Query, connexion);

            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                int n = rdr.FieldCount;

                while (rdr.Read())
                {
                    Dictionary<string, string> minres = new Dictionary<string, string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        minres.Add(rdr.GetName(i), Convert.ToString(rdr[i]));
                    }
                    result.Add(minres);
                }
            }
            cmd = null;
            return result;
        }

        public static void Insert(string Table)
        {
            string Query = @"INSERT INTO `" + Table + "` (`pseudo`, `email`, `motpasse`) VALUES (NULL, 'Testttt', 'azefdgh', 'ggzrfv')";

            MySqlCommand cmd = new MySqlCommand(Query, connexion);

            cmd.ExecuteNonQuery();

            cmd = null;
        }
    }
}
