using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstProject.Controllers
{
    public class ScientificWorksController : Controller
    {
        private IScientificWorkService _scientificWorkService;
        private ISubjectService _subjectService;
        private ITeacherService _teachers;
        public ScientificWorksController(IScientificWorkService scientificWorkService, ISubjectService subjectService, ITeacherService teacherService)
        {
            _scientificWorkService = scientificWorkService;
            _subjectService = subjectService;
            _teachers = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var ScientificWorks = await _scientificWorkService.GetScientificWorks();
            return View(ScientificWorks);

        }
        public async Task<IActionResult> InfoForScientificWork(int id)
        {
            var ScientificWork = await _scientificWorkService.GetScientificWork(id);
            return View(ScientificWork);
        }

        [HttpGet]
        public async Task<IActionResult> AddScientificWork(int studentId, int id)
        {
            ScientificWorkViewModel scientificWorkViewModel;
            var subjects = await _subjectService.GetSubjects();
            var subjectsSort = subjects.Select(x => new SelectListItem() { Text = x.Title, Value = x.Id.ToString() });
            var teachets = await _teachers.GetTeachers();
            var teachetsSort = teachets.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            if (id == 0)
            {

                scientificWorkViewModel = new ScientificWorkViewModel()
                {
                    Subjects = subjectsSort.ToList(),
                    StudentId = studentId,
                    Teachers = teachetsSort.ToList()
                };
            }
            else
            {
                var scientificWork = await _scientificWorkService.GetScientificWork(id);
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
        public async Task<IActionResult> AddScientificWork(ScientificWorkViewModel scintificWorkViewModel)
        {
            Subject subject = new Subject() { Id = scintificWorkViewModel.SubjectId };
            Teacher teacher = new Teacher() { Id = scintificWorkViewModel.TeacherId };
            Student student = new Student() { Id = scintificWorkViewModel.StudentId };

            ScientificWork scientificWork = new ScientificWork(scintificWorkViewModel.Title, subject, teacher, student);
            if (scintificWorkViewModel.Id == 0)
            {
                await _scientificWorkService.AddScientificWork(scientificWork);
            }
            else
            {
                scientificWork.Id = scintificWorkViewModel.Id;
                await _scientificWorkService.Update(scientificWork);
            }

            return RedirectToAction("InfoForStudent", "Students", new { id = student.Id });
        }
    }
}

