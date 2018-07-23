using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Models
{
  public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Students> Students { get; set; }

        public ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
