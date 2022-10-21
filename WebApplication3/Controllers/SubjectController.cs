using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System.Threading.Tasks;

namespace MyFirstProject.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectService _subjectService;
        public SubjectController (ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectService.GetSubjects();
            return View(subjects);
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSubject(SubjectViewModel subjectViewModel)
        {
            Subject subject = new Subject(subjectViewModel.Title);
            await _subjectService.AddSubject(subject);
            return View();
        }
    }
}
