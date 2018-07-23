using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlEFCore.Models
{
   public class TClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }

        public virtual List<TeacherClass> TeacherClass { get; set; }
    }
}
