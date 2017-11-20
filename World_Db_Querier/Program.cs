using System;
using MySql.Data.MySqlClient;

namespace World_Db_Querier
{
    class Program
    {
        static string version = "0.4";

        static void TotalCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=world;Uid=Imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            conn.Open();

            int output = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Aantal landen : {0}", output);
        }

        static void PrintCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=world;Uid=Imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT name FROM world.Country";

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine((string)reader["Name"]);
            }
        }

        static void FindCountry(string parameter)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=world;Uid=Imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "SELECT * FROM world.Country WHERE Name LIKE @parameter";
            cmd.Parameters.AddWithValue("@parameter", "%" + parameter + "%");

            

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[1]));

            }
        }

        static void Main(string[] args)
        {
            int exit = 0;
            while (exit == 0)
            {
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "-v":
                            Console.WriteLine("Versie {0}", version);
                            break;
                        default:
                            Console.WriteLine("Onbekend argument");
                            break;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("------------------------");
                Console.WriteLine("|        Menu          |");
                Console.WriteLine("------------------------");
                Console.WriteLine("1: geef aantal landen weer");
                Console.WriteLine("2: geef alle landen weer");
                Console.WriteLine("3: Een land zoeken");

                string n = Console.ReadLine();

                if (n == "1")
                {
                    TotalCountry();
                }
                else if (n == "2")
                {
                    PrintCountry();
                }
                else if (n == "3")
                {
                    Console.WriteLine("Welk land zoek je?");
                    string searchCountry = Console.ReadLine();
                    Console.WriteLine("------------------------");
                    FindCountry(searchCountry);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}