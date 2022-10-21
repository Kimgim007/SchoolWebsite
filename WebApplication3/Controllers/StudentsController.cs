using Microsoft.AspNetCore.Mvc;
using People.EntityAndService.Service;
using People.EntityAndService.Entity;
using MyFirstProject.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentsService;
        public StudentsController(IStudentService studentService)
        {
            _studentsService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var student = await _studentsService.GetStudents();
            return View(student);
        }
        public async Task<IActionResult> InfoForStudent(int id)
        {
            var student = await _studentsService.GetStudent(id);
        
            return View(student);
        }
        //public  string Name(int id)
        //{
        //    var student = _studentsService.GetStudent(id).Name;
        //    return (student);
        //}
        [HttpGet]
        public async Task<IActionResult> AddStudent(int id)
        {
            StudentViewModel StudentViewModel;

            if (id == 0)
            {
                StudentViewModel = new StudentViewModel();
            }
            else
            {
                var student = await _studentsService.GetStudent(id);
         
                StudentViewModel = new StudentViewModel()
                {
                    id = student.Id,
                    Name = student.Name,
                    Birthday = student.Birthday,
                    GenderId = (int)student.Gender,
                };
            }

            StudentViewModel.Genders = new List<SelectListItem>();

            StudentViewModel.Genders.Add(new SelectListItem { Text = "мужчина", Value = ((int)Gender.male).ToString()});
            StudentViewModel.Genders.Add(new SelectListItem { Text = "женщина", Value = ((int)Gender.female).ToString() });
            StudentViewModel.Genders.Add(new SelectListItem { Text = "другое", Value = ((int)Gender.other).ToString() });

            return View(StudentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel studentViewModel)
        {
            Student student = new Student(studentViewModel.Name, studentViewModel.Birthday, studentViewModel.GenderId);
            if (studentViewModel.id == 0)
			{
                 await _studentsService.AddStudent(student);      
            }
            else
			{
                student.Id = studentViewModel.id;
               await _studentsService.UpdateStudent(student);
			}
            return RedirectToAction("Index", "Students");
        }
    }
}
