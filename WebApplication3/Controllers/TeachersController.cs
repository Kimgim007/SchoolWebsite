using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstProject.Controllers
{
    public class TeachersController : Controller
    {
        private ITeacherService _service;
        public TeachersController(ITeacherService teacherService)
        {
            _service = teacherService;
        }
        public async Task<IActionResult> Index()
        {
           
            var teacher = await _service.GetTeachers();
            return View(teacher);
        }
        public async Task<IActionResult> InfoForTeacher(int id )
        {
           
            var teacher = await _service.GetTeacher(id);
            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> AddTeacher(int id)
        {
            TeacherViewModel teacherViewModel;

            if (id == 0)
            {
                 teacherViewModel = new TeacherViewModel();
             
            }
            else
            {
                var teacher = await _service.GetTeacher(id);
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
        public async Task<IActionResult> AddTeacher(TeacherViewModel teachersViewController)
        {
            Teacher teacher = new Teacher(teachersViewController.Name, teachersViewController.Birthday, teachersViewController.GenderId, teachersViewController.ZP);
            if (teachersViewController.id == 0)
            {
                await _service.AddTeacher(teacher);
            }
            else
            {
                teacher.Id = teachersViewController.id;
                await _service.UpdateTeacher(teacher);
            }
            return RedirectToAction("Index", "Teachers");
        }
    }
}
