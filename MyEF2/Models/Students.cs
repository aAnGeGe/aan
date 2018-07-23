using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Models
{
    public class Students
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
