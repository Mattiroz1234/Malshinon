using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    internal class AlertDAL
    {
        public static void AddAlert(int targetId, string reason)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "INSERT INTO alerts (target_id, reason) VALUES (@targetId, @reason)";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@targetId", targetId);
                    cmd.Parameters.AddWithValue("@reason", reason);

                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("A new alert has been created.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }
    }
}
