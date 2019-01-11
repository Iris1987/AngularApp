using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]")]
    public class HomeController 
    {
        public IActionResult Index()
        {
            return null;

        }
        /*
         [Authorize]
        public IActionResult Index()
        {
            Teacher teacher = teacherService.GetTeachers().Where(t => t.Login == User.Identity.Name).SingleOrDefault();
            Student student = studentService.GetStudents().Where(s => s.Username == User.Identity.Name).SingleOrDefault();

            if (teacher != null)
            {
                TeacherViewModel teacherViewModel = new TeacherViewModel() {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    Lastname = teacher.Lastname,
                    Login = teacher.Login,
                    Password = teacher.Password
                };

                return RedirectToAction("Index", "Teacher", teacherViewModel);
            }
            else if(student != null)          
            {
                return RedirectToAction("Index", "Student");
            }

            return View();
            
        }*/

    }
}
