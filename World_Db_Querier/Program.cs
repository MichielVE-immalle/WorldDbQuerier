﻿using System;
using MySql.Data.MySqlClient;

namespace World_Db_Querier
{
    class Program
    {
        static string version = "0.1";

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

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=Concerten;Uid=Imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            conn.Open();

            int aantalArtiesten = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Aantal landen : {0}", aantalArtiesten);
        }
    }
}