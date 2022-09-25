using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;

namespace MyFirstProject.Controllers
{
    public class SubjectController : Controller
    {
        private SubjectService _subjectService;
        public SubjectController (SubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {
            var subjects = _subjectService.GetSubjects();
            return View(subjects);
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(SubjectViewModel subjectViewModel)
        {
            Subject subject = new Subject(subjectViewModel.Title);
            _subjectService.AddSubject(subject);
            return View();
        }
    }
}
