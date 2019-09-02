using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace AsxScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AsxScraper";

            Console.Write("Enter a 3-character ASX ticker code to display the price of: ");
            var input = Console.ReadLine();

            if (input.Length != 3)
            {
                Console.Write("Error: the ticker code you enter must be 3 characters. Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }


            var details = JObject.Parse(new WebClient().DownloadString("https://www.asx.com.au/asx/1/share/" + input.ToUpper()));

            Console.WriteLine(string.Concat(details["code"], ": " + details["last_price"]));

            // this works too
            // Console.WriteLine(new WebClient().DownloadString("https://www.asx.com.au/asx/research/ASXListedCompanies.csv"));

            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
