using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System.Linq;

namespace MyFirstProject.Controllers
{
    public class LecturesController : Controller
    {
        private LectureService _lectureService;
        private TeacherService _teacherService;
        private SubjectService _subjectService;
        public LecturesController(LectureService lectureService, TeacherService teacherService, SubjectService subjectService)
        {
            _lectureService = lectureService;
            _teacherService = teacherService;
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {

            var lectures = _lectureService.GetLectures();
            return View(lectures);
        }
        public IActionResult InfoForLecture(int id)
        {

            var lectures = _lectureService.GetLecture(id);
            return View(lectures);
        }
        [HttpGet]
        public IActionResult AddLecture(int id)
        {
            LecturesViewModel LecturesViewModel;


            var subjects = _subjectService.GetSubjects().Select(x => new SelectListItem() { Text = x.Title, Value = x.Id.ToString() });
            var teachets = _teacherService.GetTeachers().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            if (id == 0)
            {
                LecturesViewModel = new LecturesViewModel()
                {
                    Subjects = subjects.ToList(),
                    Teachers = teachets.ToList()
                };
            }
            else
            {
                var lecture = _lectureService.GetLecture(id);
                LecturesViewModel = new LecturesViewModel()
                {
                    id = lecture.Id,
                   
                    Subjects = subjects.ToList(),
                    SubjectId = lecture.Subject.Id,

                    iteName = lecture.itemName,
                    dataTime = lecture.DateTime,

                    Teachers = teachets.ToList(),
                    TeacherId = lecture.Teacher.Id,
                };
            }
            return View(LecturesViewModel);
        }
        [HttpPost]
        public IActionResult AddLecture(LecturesViewModel lecturesViewModel)
        {
            Subject subject = new Subject() { Id = lecturesViewModel.SubjectId };
            Teacher teacher = new Teacher() { Id = lecturesViewModel.TeacherId };

            Lecture Lecture = new Lecture(subject, lecturesViewModel.dataTime, lecturesViewModel.iteName, teacher);
           
            if(lecturesViewModel.id == 0)
            {
                _lectureService.AddLecture(Lecture);
            }
            else
            {
                Lecture.Id = lecturesViewModel.id;
                _lectureService.UpdateLecture(Lecture);
            }

            return RedirectToAction("Index", "Lectures");
        }
    }
}
