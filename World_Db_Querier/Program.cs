using System;

namespace World_Db_Querier
{
    class Program
    {
        static string version = "0.1";


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
            else
            {
                Console.WriteLine("Hello World");
            }
        }
    }
}
