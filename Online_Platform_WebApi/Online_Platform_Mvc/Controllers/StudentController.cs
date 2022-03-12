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
    public class StudentController : Controller
    {

        HttpClient client;
        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22190/api/Students/");
            //client.DefaultRequestHeaders.Accept.Clear();
        }

        [HttpGet]
        public async Task<IActionResult> StudentsList()
        {
            List<StudentModel> studentModel = await client.GetFromJsonAsync<List<StudentModel>>("getallstudents");

            return View("StudentsList",studentModel);
        }
    }
}
