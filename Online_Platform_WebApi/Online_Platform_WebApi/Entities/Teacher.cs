using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Entities
{
    public class Teacher
    {
        
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
