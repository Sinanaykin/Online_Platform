using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_Mvc.Models
{
    public class HomeworkModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Directive { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
