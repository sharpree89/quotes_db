﻿using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using DbConnection;

namespace Quotes
{
    public class Program
    {
          public static void Create()
          {
            Console.WriteLine("Creating A New Quote");
            Console.Write("Enter first name: ");
            string user = Console.ReadLine();

            Console.Write("Enter a quote: ");
            string quote = Console.ReadLine();
            
            string query = $"INSERT INTO quotes (user, quote, created_at) VALUES('{user}', '{quote}', NOW())";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine("The quote has been added to the db!");
          }

        //   public static void Read()
        //   {
        //     List<Dictionary<string, object>> results = DbConnector.ExecuteQuery("SELECT * FROM quotes");
        //     foreach(Dictionary<string,object> item in results)
        //     {
        //         Console.WriteLine(item["id"] + ". " + item["user"] + " said: " + "'" + item["quote"] + "'" + " @ " + item["created_at"] + " | " + item["updated_at"]);
        //     }
        //   }

        // public static void Update()
        // {
        //     Console.WriteLine("Enter quote ID to be updated:  ");

        //     string quoteId = Console.ReadLine();
        //     int quote_id = Int32.Parse(quoteId);

        //     Console.WriteLine("Enter new user name: ");
        //     string user = Console.ReadLine();

        //     Console.WriteLine("Enter new quote: ");
        //     string quote = Console.ReadLine();

        //     string query = $"UPDATE quotes SET user = '{user}', quote = '{quote}', updated_at = NOW() WHERE id = {quote_id}";
        //     DbConnector.ExecuteQuery(query);
        //     Console.WriteLine($"Quote #{quote_id} has been updated!");
        // }

        // public static void Destroy()
        // {
        //     Console.WriteLine("Enter quote ID to be deleted:  ");

        //     string quoteId = Console.ReadLine();
        //     int quote_id = Int32.Parse(quoteId);

        //     string query = $"DELETE FROM quotes WHERE id = {quote_id}";
        //     DbConnector.ExecuteQuery(query);
        //     Console.WriteLine($"The quote has been deleted!");
        // }

        public static void Main(string[] args)
        {  
            // Create();
            // Read();
            // Destroy();

            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
                
        }
    }
}
