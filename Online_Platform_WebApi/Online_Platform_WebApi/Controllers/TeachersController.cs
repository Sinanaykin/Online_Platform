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
    public class TeachersController : ControllerBase
    {

        private readonly OnlinePlatformDbContext _onlinePlatformDbContext;
        public TeachersController(OnlinePlatformDbContext onlinePlatformDbContext)
        {
            _onlinePlatformDbContext = onlinePlatformDbContext;
        }


        [HttpPost("login")]
        public IActionResult Login(Dictionary<string,string> name)
        {
            string x="";

            if (!name.TryGetValue("name",out x ))
            {
                return BadRequest("Name alanı boş geçilemez");
            }
            var user = _onlinePlatformDbContext.Teachers.Where(p => p.Name == x).FirstOrDefault();
            if (user==null)
            {
                return BadRequest("İsim bulunamadı");
            }
            return Ok("Hoşgeldiniz " + x);
            
        }


        [HttpGet("getallteachers")]
        public IActionResult GetAllTeachers()
        {
            // var teachers = _onlinePlatformDbContext.Teachers.ToList(); 2 . YOL
            var teachers = _onlinePlatformDbContext.Teachers.Select(x => new TeacherModel() //Entity dönmesinin istersek direk select i yazmaya gerek yoktu
            {
              
                TeacherId = x.TeacherId,
               
                Name = x.Name,
                LastName = x.LastName

            }).ToList();

            return Ok(teachers);
        }
  
        [HttpGet("getteachersbylesson/{id}")]
        public IActionResult GetTeacherByLesson(int id)
        {


            var result = _onlinePlatformDbContext.Lessons.Where(i => i.LessonId == id).Select(i => i.Teacher).ToList();

            return Ok(result);
        }
        [HttpGet("getteacherbyid/{id}")]
        public IActionResult GetTeacherById(int id)
        {

            var teacher = _onlinePlatformDbContext.Teachers.Select(x => new TeacherModel()
            {
                Name = x.Name,
                LastName = x.LastName,
                TeacherId = x.TeacherId
            }).Where(t => t.TeacherId == id).FirstOrDefault();

            return Ok(teacher);
        }

        //[HttpPost("addteachers")] //2. yol
        //public IActionResult AddTeachers(Teacher teacher)
        //{
        //    var addedteacher = _onlinePlatformDbContext.Entry(teacher);
        //    addedteacher.State = EntityState.Added;
        //    _onlinePlatformDbContext.SaveChanges();
        //    return Ok("Eklendi");
        //}

        [HttpPost("addteacher")]
        public IActionResult AddTeacher(Teacher teacher)
        {
          
                _onlinePlatformDbContext.Teachers.Add(teacher);

                _onlinePlatformDbContext.SaveChanges();
                return Ok("Eklendi");
           
        }





        //[HttpPost("updateteacher")]  
        //public IActionResult UpdateTeacher(Teacher teacher)  //2.yol
        //{
        //    var updatedentity = _onlinePlatformDbContext.Entry(teacher);//contexte bizim göndereceğimiz car(entity) yakala
        //    updatedentity.State = EntityState.Modified;//ilişkilendiidriğimiz yapıyı güncelle demek bu
        //    _onlinePlatformDbContext.SaveChanges();//değişiklikleri kaydet
        //    return Ok("Güncellendi");
        //}

        [HttpPost("updateteacher")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {

            var t = _onlinePlatformDbContext.Teachers.Where(x => x.TeacherId == teacher.TeacherId).FirstOrDefault();

            t.TeacherId = teacher.TeacherId;
            t.Name = teacher.Name;
            t.LastName = teacher.LastName;

            _onlinePlatformDbContext.SaveChanges();
            return Ok("Güncellendi");


        }



        //[HttpPost("deleteteachers")]
        //public IActionResult DeleteTeachers(Teacher teacher)
        //{
        //    var deletedentity = _onlinePlatformDbContext.Entry(teacher);
        //    deletedentity.State = EntityState.Deleted;
        //    _onlinePlatformDbContext.SaveChanges();
        //    return Ok("Silindi");
        //}



        //[HttpPost("deleteteacher")]
        //public IActionResult DeleteTeachers(Teacher teacher) //3.yol
        //{
        //    var t = _onlinePlatformDbContext.Teachers.Where(t => t.TeacherId ==teacher.TeacherId).FirstOrDefault();
        //    var deleteteacher = _onlinePlatformDbContext.Teachers.Remove(t);
        //    _onlinePlatformDbContext.SaveChanges();
        //    return Ok("Silindi");
        //}


        [HttpPost("deleteteacher/{id}")]
        public IActionResult DeleteTeachers(int id)
        {
            var teacher = _onlinePlatformDbContext.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
            var deleteteacher = _onlinePlatformDbContext.Teachers.Remove(teacher);
            _onlinePlatformDbContext.SaveChanges();
            return Ok("Silindi");
        }



    }
}
