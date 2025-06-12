using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A new alert has been created.");
                Console.ResetColor();
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


        public static void GetActiveAlerts()
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "SELECT * FROM alerts WHERE reason = 'Rapid reports detected'";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int targetId = reader.GetInt32("target_id");
                            DateTime timestamp = reader.GetDateTime("timestamp");
                            string reason = reader.GetString("reason");


                            Console.WriteLine($"An alert was created on: {timestamp} for target number: {targetId} because:{reason}.");
                        }
                    }
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


        public static void GetDangers()
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "SELECT a.target_id AS tarId, p.num_mentions AS num FROM people AS p JOIN alerts AS a ON a.target_id = p.id WHERE a.reason = 'It has more than 20 reports'";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int targetId = reader.GetInt32("tarId");
                            int numMun = reader.GetInt32("num");



                            Console.WriteLine($"target number: {targetId} hes nummentions: {numMun}.");
                        }
                    }
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
