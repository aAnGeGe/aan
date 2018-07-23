using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlEFCore.Models
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int ClassId { get; set; }
        public virtual TClass TClass { get; set; }
    }
}
