using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Entities
{
    public class TeacherStudent
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public Teacher Teacher { get; set; }
       
        public Student Student { get; set; }
    }
}
