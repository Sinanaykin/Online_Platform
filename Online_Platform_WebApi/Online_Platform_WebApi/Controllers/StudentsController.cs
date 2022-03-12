using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Platform_WebApi.DataAccess;
using Online_Platform_WebApi.Entities;
using Online_Platform_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly OnlinePlatformDbContext _onlinePlatformDbContext;
        public StudentsController(OnlinePlatformDbContext onlinePlatformDbContext)
        {
            _onlinePlatformDbContext = onlinePlatformDbContext;
        }

        [HttpPost("login")]
        public IActionResult Login(Dictionary<string, string> name)
        {
            string x = "";

            if (!name.TryGetValue("name", out x))
            {
                return BadRequest("Name alanı boş geçilemez");
            }
            var user = _onlinePlatformDbContext.Students.Where(p => p.Name == x).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("İsim bulunamadı");
            }
            return Ok("Hoşgeldiniz " + x);

        }


        [HttpGet("getallstudents")]
        public IActionResult GetAllStudents()
        {
            // var teachers = _onlinePlatformDbContext.Teachers.ToList(); 2 . YOL
            var students = _onlinePlatformDbContext.Students.Select(x => new StudentModel()
            {
               StudentId=x.StudentId,
               Name=x.Name,
               LastName=x.LastName,
               

            }).ToList();

            return Ok(students);
        }

     

        [HttpGet("getstudentbyid/{id}")]
        public IActionResult GetStudentById(int id)
        {

            var student = _onlinePlatformDbContext.Students.Select(x => new StudentModel()
            {
                StudentId = x.StudentId,
                Name = x.Name,
                LastName = x.LastName
            }).Where(t => t.StudentId == id).FirstOrDefault();

            return Ok(student);
        }

       

        [HttpPost("addstudent")]
        public IActionResult AddTeacher(Student student)
        {
            
                _onlinePlatformDbContext.Students.Add(student);

                _onlinePlatformDbContext.SaveChanges();
                return Ok("Eklendi");
            
        
        }
    }
}
