using System;
using Microsoft.Owin.Hosting;

namespace CodedUI.jQueryExtensions.WebsiteHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "http://localhost:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on http://localhost:8080", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}