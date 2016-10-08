using System;
using System.Collections.Generic;
using Nancy;
using DbConnection;
 
namespace Quotes 
{
    public class QuotesModule : NancyModule  
    {
        public QuotesModule()
        {
            Get("/", args =>
            {
                return View["index.sshtml"];   
            }); 

            Post("/process", args => 
            {
                Console.WriteLine("Creating A New Quote");
                
                string user = Request.Form["name"];

                string quote = Request.Form["quote"];
                
                string query = $"INSERT INTO quotes (user, quote, created_at) VALUES('{user}', '{quote}', NOW())";
                DbConnector.ExecuteQuery(query);
                Console.WriteLine("The quote has been added to the db!");

                return Response.AsRedirect("/quotes");  
                
            });  

            Get("/quotes", args =>    
            {
                @ViewBag.quotes = "";

                List<Dictionary<string, object>> results = DbConnector.ExecuteQuery("SELECT * FROM quotes");
                results.Reverse();
                foreach(Dictionary<string,object> item in results)
                {
                    @ViewBag.quotes += "<p>" + "<b>" + item["user"] + "</b>" + " said: " + "'" + item["quote"] + "'" + "<i>" + " @ " + item["created_at"] + "</i>" + "</p>" + "<hr>";
                }
                return View["quotes.sshtml", results]; 
            }); 
        }
    }
}