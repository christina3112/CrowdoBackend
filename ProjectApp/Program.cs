using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectApp.Services;

namespace ProjectApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Data data = new Data();

            ProjectItem proj = new ProjectItem()
            {

                ProjectCode = "P26",
                UserCode = "C3",
                Title = "Zzzz",
                Description = "hfdjksajbfj",
                StartDate = DateTime.Now,
                PackageCode = "Pack1,Pack2,Pack4",
                NumberOfRequestedPackages = "10,20,5"
            };

            /*double total = data.GetTotalReceivingFunds(proj);
            Console.WriteLine($"the total is : {total}");*/
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
