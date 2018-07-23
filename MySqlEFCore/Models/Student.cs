using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlEFCore.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int ClassId { get; set; }
        public virtual TClass TClass { get; set; }
    }
}
