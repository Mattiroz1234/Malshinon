using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    internal class ReportDAL
    {
        public static void AddReport(int reporterId, int targetId, string text)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "INSERT INTO intelreports (reporter_id, target_id, text) VALUES (@reporterId, @targetId, @text)";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@reporterId", reporterId);
                    cmd.Parameters.AddWithValue("@targetId", targetId);
                    cmd.Parameters.AddWithValue("@text", text);
                    
                    cmd.ExecuteNonQuery();
                }
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
