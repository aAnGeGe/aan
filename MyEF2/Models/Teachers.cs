using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
