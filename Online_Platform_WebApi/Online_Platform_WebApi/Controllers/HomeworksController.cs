using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class HomeworksController : ControllerBase
    {

        private readonly OnlinePlatformDbContext _onlinePlatformDbContext;
        public HomeworksController(OnlinePlatformDbContext onlinePlatformDbContext)
        {
            _onlinePlatformDbContext = onlinePlatformDbContext;
        }
        [HttpGet("getallhomework")]
        public IActionResult GetAllHomeworks()
        {
            // var teachers = _onlinePlatformDbContext.Teachers.ToList(); 2 . YOL
            var homeworks = _onlinePlatformDbContext.Homeworks.Select(x => new HomeworkModel()
            {
                HomeworkId = x.HomeworkId,
                Name = x.Name,
                Directive = x.Directive,
                DeliveryDate = x.DeliveryDate

            }).ToList();

            return Ok(homeworks);
        }

        [HttpGet("gethomeworkbyid/{id}")]
        public IActionResult GetHomeworkById(int id)
        {

            var homework = _onlinePlatformDbContext.Homeworks.Select(x => new HomeworkModel()
            {
                HomeworkId = x.HomeworkId,
                Name = x.Name,
                Directive = x.Directive,
                DeliveryDate = x.DeliveryDate
            }).Where(t => t.HomeworkId == id).FirstOrDefault();

            return Ok(homework);
        }



        [HttpPost("addhomework")]
        public IActionResult AddTeacher(HomeworkModel homeworkModel)
        {


            var homework = new Homework()
            {

                Name = homeworkModel.Name,
                Directive = homeworkModel.Directive,
                DeliveryDate = homeworkModel.DeliveryDate,
                LessonId = homeworkModel.LessonId


            };


            _onlinePlatformDbContext.Homeworks.Add(homework);
            _onlinePlatformDbContext.SaveChanges();
            return Ok("Eklendi");


        }
    }
}

