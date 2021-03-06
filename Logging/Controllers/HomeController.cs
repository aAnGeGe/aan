﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logging.Models;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            string str = "123";
            
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogDebug("这是一个调试信息");
            _logger.LogWarning("这是一个警告信息");

            try
            {
                string s = null;
                s.ToString();
            }catch(Exception ex)
            {
                _logger.LogError(new EventId(),ex,ex.Message);
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
        
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current.Id ?? HttpContext.TraceIdentifier });
        }


     

    }
}
