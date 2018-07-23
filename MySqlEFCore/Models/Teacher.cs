using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlEFCore.Models
{
   public class Teacher
    {
        public int Id { get; set; }
        public string Nameg { set; get; }
        public virtual List<TeacherClass> TeacherClass { get; set; }
    }
}
