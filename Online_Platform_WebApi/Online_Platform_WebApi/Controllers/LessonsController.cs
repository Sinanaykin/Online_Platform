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

namespace Online_Platform_WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly OnlinePlatformDbContext _onlinePlatformDbContext;
        public LessonsController(OnlinePlatformDbContext onlinePlatformDbContext)
        {
            _onlinePlatformDbContext = onlinePlatformDbContext;
        }
        [HttpGet("getalllessons")]
        public IActionResult GetAllLessons()
        {
            // var teachers = _onlinePlatformDbContext.Teachers.ToList(); 2 . YOL
            var lessons = _onlinePlatformDbContext.Lessons.Select(x => new LessonModel()
            {
                LessonId=x.LessonId,
                Name=x.Name,
                Time=x.Time
            }).ToList();

            return Ok(lessons);
        }
        [HttpGet("gethomeworkbylessonıd/{id}")]
        public IActionResult GetHomeworkByLessonId(int id)
        {

            var result = _onlinePlatformDbContext.Homeworks.Include(i => i.Lesson).Where(i => i.LessonId == id).Select(i => i.Lesson).ToList();
            //var result = _onlinePlatformDbContext.LessonStudents.Include(i => i.Student).Where(i => i.LessonId == id).Select(i => i.Student).ToList();

            return Ok(result);
        }


        [HttpGet("getallstudentsbylesson/{id}")]
        public IActionResult GetAllStudentsByLesson(int id)
        {

          
            var result = _onlinePlatformDbContext.LessonStudents.Include(i=>i.Student).Where(i => i.LessonId == id).Select(i => i.Student).ToList();

            return Ok(result);
        }

      

        [HttpGet("getlessonbyid/{id}")]
        public IActionResult GetLessonById(int id)
        {

            var lesson = _onlinePlatformDbContext.Lessons.Select(x => new LessonModel()
            {
              LessonId=x.LessonId,
              Name=x.Name,
              Time=x.Time
            }).Where(t => t.LessonId == id).FirstOrDefault();

            return Ok(lesson);
        }

        //[HttpPost("addlesson")]
        //public IActionResult AddLesson(Lesson lesson)
        //{
        //    try
        //    {
        //        _onlinePlatformDbContext.Lessons.Add(lesson);
        //        if (lesson.Teacher==null)
        //        {

        //        }
        //        _onlinePlatformDbContext.SaveChanges();
        //        return Ok("Eklendi");
        //    }
        //    catch (Exception a)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost("addlesson")]
        public IActionResult AddLesson(LessonModel lessonModel)
        {

            var lesson = new Lesson()
            {
           
                Name = lessonModel.Name,
                TeacherId = lessonModel.TeacherId,
                Time = lessonModel.Time

            };


            _onlinePlatformDbContext.Lessons.Add(lesson);
            _onlinePlatformDbContext.SaveChanges();
            return Ok("Eklendi");

        }





    }
}
