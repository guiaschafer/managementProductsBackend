using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace ManagementProduts.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //{
        //    var defaultBuilder = WebHost
        //        .CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
        //    defaultBuilder.ConfigureAppConfiguration((builder, config) =>
        //    {
        //        IHostingEnvironment env = builder.HostingEnvironment;
        //        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //    });
        //    return defaultBuilder;
        //}
    }
}
