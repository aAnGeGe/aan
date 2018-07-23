using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISayHelloService : IServiceBase
    {
        string SayHello();
    }
}
