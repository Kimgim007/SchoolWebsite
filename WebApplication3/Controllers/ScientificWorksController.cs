using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstProject.Controllers
{
    public class ScientificWorksController : Controller
    {
        private ScientificWorkService _scientificWorkService;
        private SubjectService _subjectService;
        private TeacherService _teachers;
        public ScientificWorksController(ScientificWorkService scientificWorkService, SubjectService subjectService, TeacherService teacherService)
        {
            _scientificWorkService = scientificWorkService;
            _subjectService = subjectService;
            _teachers = teacherService;
        }

        public IActionResult Index()
        {
            var ScientificWorks = _scientificWorkService.GetScientificWorks();
            return View(ScientificWorks);

        }
        public IActionResult InfoForScientificWork(int id)
        {
            var ScientificWork = _scientificWorkService.GetScientificWork(id);
            return View(ScientificWork);
        }

        [HttpGet]
        public IActionResult AddScientificWork(int studentId,int id)
        {
            ScientificWorkViewModel scientificWorkViewModel;
            var subjects = _subjectService.GetSubjects().Select(x => new SelectListItem() { Text = x.Title, Value = x.Id.ToString() });
            var teachets = _teachers.GetTeachers().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            if(id == 0)
            {
               
                scientificWorkViewModel = new ScientificWorkViewModel()
                {
                    Subjects = subjects.ToList(),
                    StudentId = studentId,
                    Teachers = teachets.ToList()
                };
            }
            else
            {
                var scientificWork = _scientificWorkService.GetScientificWork(id);
                scientificWorkViewModel = new ScientificWorkViewModel()
                {
                    Id = scientificWork.Id,
                    Title = scientificWork.Title,
                    SubjectId = scientificWork.Subject.Id,
                    TeacherId = scientificWork.Teacher.Id,
                    StudentId = scientificWork.Student.Id

                };
            }
            return View(scientificWorkViewModel);
        }
        [HttpPost]
        public IActionResult AddScientificWork(ScientificWorkViewModel scintificWorkViewModel)
        {
            Subject subject = new Subject() { Id = scintificWorkViewModel.SubjectId };
            Teacher teacher = new Teacher() { Id = scintificWorkViewModel.TeacherId };
            Student student = new Student() { Id = scintificWorkViewModel.StudentId };

            ScientificWork scientificWork = new ScientificWork(scintificWorkViewModel.Title, subject, teacher, student);
            if (scintificWorkViewModel.Id == 0)
            {
                _scientificWorkService.AddScientificWork(scientificWork);
            }
            else
            {
                scientificWork.Id = scintificWorkViewModel.Id;
                _scientificWorkService.Update(scientificWork);
            }
          
            return RedirectToAction("InfoForStudent", "Students", new { id = student.Id });
        }
    }
}

