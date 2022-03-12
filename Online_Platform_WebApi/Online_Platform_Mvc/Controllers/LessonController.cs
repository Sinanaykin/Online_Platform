using Microsoft.AspNetCore.Mvc;
using Online_Platform_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Platform_Mvc.Controllers
{
    public class LessonController : Controller
    {


        HttpClient client;
        public LessonController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22190/api/Lessons/");
            //client.DefaultRequestHeaders.Accept.Clear();
        }
        [HttpGet]
        public IActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonModel lessonModel)
        {
            
             await client.PostAsJsonAsync<LessonModel>("addlesson",lessonModel);
            return View("AddLesson",lessonModel);
        }
    }
}
