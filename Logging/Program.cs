using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseStartup<Startup>().ConfigureLogging(logging =>
            {
               // logging.ClearProviders();  //移除已经注册的其他日志处理程序，比如调试时的控制台的信息
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //设置最小的日志级别
            })
            .UseNLog();  // 将NLog依赖注入

    }
}
