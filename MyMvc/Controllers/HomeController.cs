using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyMvc.Models;
using Services;

namespace MyMvc.Controllers
{
    public class HomeController : Controller
    {
        private ISayHelloService sayHello;
        private IStudentService StudentService;
        private IUserService userService;
        private HellowServer hellow;
        public HomeController(HellowServer hellow,ISayHelloService sayHello, IStudentService StudentService , IUserService userService)
        {
            this.hellow = hellow;
            this.sayHello = sayHello;
            this.StudentService = StudentService;
            this.userService = userService;
        }


        public IActionResult Index()
        {
            //return Content(HellowServer.Hellow());
            return Content(sayHello.SayHello());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "你的应用程序描述界面.";

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
