using System;
using MySql.Data.MySqlClient;

namespace World_Db_Querier
{
    class Program
    {
        static string version = "0.2";

        static void TotalCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=Concerten;Uid=Imma;Pwd=imma;";

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
                "Server=192.168.56.101;Port=3306;Database=Concerten;Uid=Imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT name FROM world.Country";

            conn.Open();

            int output = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine(" landen : {0}", output);
        }

        static void Main(string[] args)
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
        }
    }
}