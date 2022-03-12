using Microsoft.AspNetCore.Mvc;
using Online_Platform_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Online_Platform_Mvc.Controllers
{
    public class HomeworkController : Controller
    {
        HttpClient client;
        public HomeworkController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22190/api/Homeworks/");
            //client.DefaultRequestHeaders.Accept.Clear(); fffsd
        }

        [HttpGet]
        public async Task<IActionResult> HomeworksList()
        {
            List<HomeworkModel> homeworksModel = await client.GetFromJsonAsync<List<HomeworkModel>>("getallhomework");

            return View("HomeworksList", homeworksModel);
        }
        [HttpGet]
        public IActionResult AddHomework()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHomework(HomeworkModel homeworkModel)
        {

            await client.PostAsJsonAsync<HomeworkModel>("addhomework", homeworkModel);
            return View("AddHomework", homeworkModel);
        }
    }
}
