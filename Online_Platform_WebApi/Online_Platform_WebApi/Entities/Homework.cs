using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Entities
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Name { get; set; }
        public string Directive { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }

    }
}
