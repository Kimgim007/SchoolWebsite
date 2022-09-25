using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System.Collections.Generic;

namespace MyFirstProject.Controllers
{
    public class TeachersController : Controller
    {
        private TeacherService _service;
        public TeachersController(TeacherService teacherService)
        {
            _service = teacherService;
        }
        public IActionResult Index()
        {
           
            var teacher = _service.GetTeachers();
            return View(teacher);
        }
        public IActionResult InfoForTeacher(int id )
        {
           
            var teacher = _service.GetTeacher(id);
            return View(teacher);
        }
        [HttpGet]
        public IActionResult AddTeacher(int id)
        {
            TeacherViewModel teacherViewModel;

            if (id == 0)
            {
                 teacherViewModel = new TeacherViewModel();
             
            }
            else
            {
                var teacher =_service.GetTeacher(id);
                teacherViewModel = new TeacherViewModel()
                {
                    id = id,
                    Name = teacher.Name,
                    Birthday = teacher.Birthday,
                    GenderId = (int)teacher.Gender,
                    ZP = teacher.ZP.ToString(),
                };
            }

            teacherViewModel.Genders = new List<SelectListItem>();

            teacherViewModel.Genders.Add(new SelectListItem { Text = "мужчина", Value = ((int)Gender.male).ToString() });
            teacherViewModel.Genders.Add(new SelectListItem { Text = "женщина", Value = ((int)Gender.female).ToString() });
            teacherViewModel.Genders.Add(new SelectListItem { Text = "другое", Value = ((int)Gender.other).ToString() });

            return View(teacherViewModel);
        }
        [HttpPost]
        public IActionResult AddTeacher(TeacherViewModel teachersViewController)
        {
            Teacher teacher = new Teacher(teachersViewController.Name, teachersViewController.Birthday, teachersViewController.GenderId, teachersViewController.ZP);
            if (teachersViewController.id == 0)
            {
                _service.AddTeacher(teacher);
            }
            else
            {
                teacher.Id = teachersViewController.id;
                _service.UpdateTeacher(teacher);
            }
            return RedirectToAction("Index", "Teachers");
        }
    }
}
