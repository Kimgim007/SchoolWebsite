using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstProject.Controllers
{
    public class LecturesController : Controller
    {
        private ILectureService _lectureService;
        private ITeacherService _teacherService;
        private ISubjectService _subjectService;
        public LecturesController(ILectureService lectureService, ITeacherService teacherService, ISubjectService subjectService)
        {
            _lectureService = lectureService;
            _teacherService = teacherService;
            _subjectService = subjectService;
        }
        public async Task<IActionResult> Index()
        {

            var lectures = await _lectureService.GetLectures();
            return View(lectures);
        }
        public async Task<IActionResult> InfoForLecture(int id)
        {

            var lectures = await _lectureService.GetLecture(id);
            return View(lectures);
        }
        [HttpGet]
        public async Task<IActionResult> AddLecture(int id)
        {
            LecturesViewModel LecturesViewModel;


            var subjects = await _subjectService.GetSubjects();
            var subjectsSort = subjects.Select(x => new SelectListItem() { Text = x.Title, Value = x.Id.ToString() });
            var teachets = await _teacherService.GetTeachers();
            var teachersSort = teachets.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            if (id == 0)
            {
                LecturesViewModel = new LecturesViewModel()
                {
                    Subjects = subjectsSort.ToList(),
                    Teachers = teachersSort.ToList()
                };
            }
            else
            {
                var lecture = await _lectureService.GetLecture(id);
                LecturesViewModel = new LecturesViewModel()
                {
                    id = lecture.Id,

                    Subjects = subjectsSort.ToList(),
                    SubjectId = lecture.Subject.Id,

                    iteName = lecture.itemName,
                    dataTime = lecture.DateTime,

                    Teachers = teachersSort.ToList(),
                    TeacherId = lecture.Teacher.Id,
                };
            }
            return View(LecturesViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddLecture(LecturesViewModel lecturesViewModel)
        {
            Subject subject = new Subject() { Id = lecturesViewModel.SubjectId };
            Teacher teacher = new Teacher() { Id = lecturesViewModel.TeacherId };

            Lecture Lecture = new Lecture(subject, lecturesViewModel.dataTime, lecturesViewModel.iteName, teacher);

            if (lecturesViewModel.id == 0)
            {
                await _lectureService.AddLecture(Lecture);
            }
            else
            {
                Lecture.Id = lecturesViewModel.id;
                await _lectureService.UpdateLecture(Lecture);
            }

            return RedirectToAction("Index", "Lectures");
        }
    }
}
