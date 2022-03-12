using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Entities
{
    public class Student
    {
    
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }
        public List<LessonStudent> LessonStudents { get; set; }
    }
}
