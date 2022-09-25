using Microsoft.AspNetCore.Mvc;
using People.EntityAndService.Service;
using People.EntityAndService.Entity;
using MyFirstProject.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        private StudentService _studentsService;
        public StudentsController(StudentService studentService)
        {
            _studentsService = studentService;
        }
        public IActionResult Index()
        {
            var student = _studentsService.GetStudents();
            return View(student);
        }
        public IActionResult InfoForStudent(int id)
        {
            var student = _studentsService.GetStudent(id);
            //switch (student.Gender)
            //{
            //    case 0:
            //        {
                        
            //            student.Gender = "Женщина".EnumValuer();
            //            break;
            //        }
            //    case 1:
            //        {
            //            student.Gender = (Gender)1;
            //            break;
            //        }
            //    case 2:
            //        {
            //            student.Gender = (Gender)2;
            //            break;
            //        }
            //}
            return View(student);
        }
        public string Name(int id)
        {
            var student = _studentsService.GetStudent(id).Name;
            return (student);
        }
        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            StudentViewModel StudentViewModel;

            if (id == 0)
            {
                StudentViewModel = new StudentViewModel();
            }
            else
            {
                var student = _studentsService.GetStudent(id);
         
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
        public IActionResult AddStudent(StudentViewModel studentViewModel)
        {
            Student student = new Student(studentViewModel.Name, studentViewModel.Birthday, studentViewModel.GenderId);
            if (studentViewModel.id == 0)
			{
                _studentsService.AddStudent(student);      
            }
            else
			{
                student.Id = studentViewModel.id;
                _studentsService.UpdateStudent(student);
			}
            return RedirectToAction("Index", "Students");
        }
    }
}
