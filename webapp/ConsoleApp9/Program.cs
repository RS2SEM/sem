
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Models;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp9
{
   class Program
    {






        public static void Main(string[] args)
        {
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
