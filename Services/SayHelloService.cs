using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    
    public class SayHelloService : ISayHelloService
    {
        private IStudentService stuService;
        private IUserService userService;
        public SayHelloService(IStudentService stuService, IUserService userService)
        {
            this.stuService = stuService;
            this.userService = userService;
        }
        public string SayHello()
        {
            return $"Hello,userCount={userService.GetUserConut()},studentCount={stuService.GetStudentCount()}";
        }
    }
}
