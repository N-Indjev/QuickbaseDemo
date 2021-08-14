using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace QB.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");
            
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Program encountered an error: \n{e}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.WriteLine("Stopping program...");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
