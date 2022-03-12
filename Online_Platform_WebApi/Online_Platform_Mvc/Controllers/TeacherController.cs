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
    public class TeacherController : Controller
    {
      
        HttpClient client;
        public TeacherController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22190/api/Teachers/");
            //client.DefaultRequestHeaders.Accept.Clear();
        }

        [HttpGet]
        public async Task<IActionResult> TeachersList()
        {
            List<TeacherModel> teachersModel = await client.GetFromJsonAsync<List<TeacherModel>>("getallteachers");

            return View("TeacherList",teachersModel);
        }
    }
}
