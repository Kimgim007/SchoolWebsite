using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyFirstProject.Models;
using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class GradesController : Controller
    {

        private LectureService _lectureService;
        private GradeSevice _gradeSevice;
        public GradesController(LectureService lectureService,GradeSevice gradeSevice)
        {
            _lectureService = lectureService;
            _gradeSevice = gradeSevice;
        }
        [HttpGet]
        public IActionResult AddGrade(int StudentId , int id)
        {
            
            var lectures = _lectureService.GetLectures().Select(x => new SelectListItem() { Text = x.itemName, Value = x.Id.ToString()});
            GradeViewModel gradeViewModel;
            if (id == 0)
            {
                gradeViewModel = new GradeViewModel()
                {
                    Lectures = lectures.ToList(),
                    StudentId = StudentId
                };
            }
            else
            {
                var grade = _gradeSevice.Get(id);
                gradeViewModel = new GradeViewModel()
                {
                    Id = id,
                    Value = grade.Value,
                    Lectures = lectures.ToList(),
                    StudentId = StudentId,
                    LectureId = grade.Lecture.Id
                };
            }

            return View(gradeViewModel);
        }
        [HttpPost]
        public IActionResult AddGrade(GradeViewModel gradeViewModel)
        {
            Lecture lecture = new Lecture() { Id = gradeViewModel.LectureId};
            Student student = new Student() { Id = gradeViewModel.StudentId };

            Grade grade = new Grade(gradeViewModel.Value, student, lecture);

            if (gradeViewModel.Id == 0)
            {

                _gradeSevice.AddGrade(grade);
            }
            else
            {
                grade.ID = gradeViewModel.Id;
                _gradeSevice.Update(grade);
            }

            if (gradeViewModel.Id == 0)
            {
                return RedirectToAction("InfoForStudent", "Students", new { id = student.Id });
            }
            else
            {
                return RedirectToAction("InfoForLecture", "Lectures", new { id = gradeViewModel.LectureId });
            }
        }

    }
}
