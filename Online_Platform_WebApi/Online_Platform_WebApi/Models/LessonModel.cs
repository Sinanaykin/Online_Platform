using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Models
{
    public class LessonModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int TeacherId { get; set; }

    }
}
