using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMvc
{
    public class HellowServer
    {
        private DataService DataService;
        public HellowServer(DataService DataSev)
        {
            DataService = DataSev;
        }
        public string Hellow()
        {
            return "Hellow word!"+DataService.GetCount();
        }
    }
}
