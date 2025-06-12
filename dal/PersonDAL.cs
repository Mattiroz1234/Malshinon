using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    internal class PersonDAL
    {

        public static int GetPersonId(string firName, string lasname)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "SELECT id FROM people WHERE first_name = @firstName AND last_name = @lastName";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@firstName", firName);
                    cmd.Parameters.AddWithValue("@lastName", lasname);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            return id;
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
            return 0;
        }


        public static Person GetPerson(int perId)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "SELECT * FROM people WHERE id = @personId";
            Person person = null;
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@personId", perId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string firstName = reader.GetString("first_name");
                            string lastName = reader.GetString("last_name");
                            string secretCode = reader.GetString("secret_code");
                            string type = reader.GetString("type");
                            int numReports = reader.GetInt32("num_reports");
                            int NumMentions = reader.GetInt32("num_mentions");

                            person = new Person(id, firstName, lastName, secretCode, type, numReports, NumMentions);
                            
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
            return person;
        }


        public static void AddPerson(string firstName, string lastName, string type)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "INSERT INTO people (first_name, last_name, type, secret_code) VALUES (@firstName, @lastName, @type, @secretCode)";
            Guid secretCode = Guid.NewGuid();
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@secretCode", secretCode.ToString());
                  
                    //using (var reader = cmd.ExecuteReader()) ;
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("A new person is added.");
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


        public static void UpdateType(int id, string newType)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "UPDATE people SET type = @newType WHERE id = @personId";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@personId", id);
                    cmd.Parameters.AddWithValue("@newType", newType);

                    //using (var reader = cmd.ExecuteReader()) ;
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("The type of person has been updated.");
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


        public static void UpdateReportsNum(int id)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "UPDATE people SET num_reports = num_reports + 1 WHERE id = @personId";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@personId", id);

                    //using (var reader = cmd.ExecuteReader()) ;
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


        public static void UpdateMentionsNum(int id)
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "UPDATE people SET num_mentions = num_mentions + 1 WHERE id = @personId";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@personId", id);

                    //using (var reader = cmd.ExecuteReader()) ;
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


        public static void GetPotentialAgents()
        {
            string connstring = "Server=127.0.0.1; database=malshinon; UID=root; password=";
            string query = "SELECT id, `num_reports` FROM people WHERE type = 'potential agents'";
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
                            int id = reader.GetInt32("id");
                            int numRepo = reader.GetInt32("num_reports");
                            int avgRepo = ReportDAL.GetAverage(id);

                            Console.WriteLine($"potential agent id: {id} has {numRepo} reports whose average is: {avgRepo}.");
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
