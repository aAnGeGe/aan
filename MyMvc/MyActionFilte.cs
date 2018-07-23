using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMvc
{
    public class MyActionFilte : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("123123");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("123123");
        }
    }
}
