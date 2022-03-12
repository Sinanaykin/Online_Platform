using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public List<Homework> Homeworks { get; set; }

        public List<LessonStudent> LessonStudents { get; set; }
    }
}
