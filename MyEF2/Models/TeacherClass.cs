using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Models
{
   public class TeacherClass
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }

        public Teachers Teachers { get; set; }
    }
}
