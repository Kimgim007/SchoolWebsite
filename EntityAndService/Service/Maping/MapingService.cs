using System.Linq;
using System.Collections.Generic;
using People.EntityAndService.Entity;
using People.Data.DTO;
using People.Data;
using Data.DTO;

namespace People.EntityAndService.Service.Maping
{
    public static class MapingService
    {
        public static StudentDTO map(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Birthday = student.Birthday,
                Gender = (GenderLib)student.Gender,

            };
        }
        public static Student map(StudentDTO student, bool getRefernce)
        {
            List<Grade> grades;
            List<ScientificWork> scientificWork = new List<ScientificWork>();

            if (getRefernce)
            {
                if (student.ScientificWork != null && student.ScientificWork.Count != 0 && student.ScientificWork[0] != null)
                {
                    //scientificWork = map(student.ScientificWork[0], true);
                    scientificWork = student.ScientificWork.Select(S => map(S, true)).ToList();
                }
                grades = student.Grades.Select(g => map(g, true)).ToList();
            }
            else
            {
                if (student.ScientificWork != null && student.ScientificWork.Count != 0 && student.ScientificWork[0] != null)
                {
                    //scientificWork = new ScientificWork() { Id = student.ScientificWork[0].Id };
                    scientificWork = student.ScientificWork.Select( s => new ScientificWork() {Id = s.Id }).ToList();
                }
                grades = student.Grades.Select(g => new Grade() { ID = g.Id }).ToList();
            }
            return new Student()
            {
                Name = student.Name,
                Birthday = student.Birthday,
                Gender = (Gender)student.Gender,
                Id = student.Id,
                Grades = grades,
                ScientificWork = scientificWork
            };
        }

        public static TeacherDTO map(Teacher teacher)
        {

            return new TeacherDTO()
            {
                Name = teacher.Name,
                Birthday = teacher.Birthday,
                Gender = (GenderLib)teacher.Gender,
                ZP = teacher.ZP,
                Id = teacher.Id
            };
        }
        public static Teacher map(TeacherDTO teacher,bool getRefernce)
        {
            List<ScientificWork> scientificWork = new List<ScientificWork>();

            if (getRefernce)
            {
                if (teacher.ScientificWorks != null && teacher.ScientificWorks.Count != 0 && teacher.ScientificWorks[0] != null)
                {
                    scientificWork = teacher.ScientificWorks.Select(S=>map(S, true)).ToList();
                }    
            }
            else
            {
                if (teacher.ScientificWorks != null && teacher.ScientificWorks.Count != 0 && teacher.ScientificWorks[0] != null)
                {
                    scientificWork = teacher.ScientificWorks.Select(s => new ScientificWork() { Id = s.Id }).ToList();
                }      
            }
            Teacher teacher1 = new Teacher()
            {
                Name = teacher.Name,
                Birthday = teacher.Birthday,
                Gender = (Gender)teacher.Gender,
                ZP = teacher.ZP,
                Id = teacher.Id,
                scientificWorks = scientificWork
            };
            if (teacher.Lectures != null)
            {
                teacher1.Lecture = teacher.Lectures.Select(l => map(l, false)).ToList();
            }
            else
            {
                teacher1.Lecture = new List<Lecture>();
            }
            return teacher1;
        }

        public static LectureDTO map(Lecture lecture)
        {
            return new LectureDTO()
            {
                Id = lecture.Id,
                SubjectId = lecture.Subject.Id,
                StartTime = lecture.DateTime,
                itemName = lecture.itemName,
                TeacherId = lecture.Teacher.Id
            };
        }
        public static Lecture map(LectureDTO lecture, bool getRefernce)
        {
            Teacher teacher;
            List<Grade> grades;
            if (getRefernce)
            {
                teacher = map(lecture.Teacher,false);
                grades = lecture.Grades.Select(g => map(g, true)).ToList();
            }
            else
            {
                teacher = new Teacher() { Id = lecture.Teacher.Id };
                grades = lecture.Grades.Select(g => new Grade() { ID = g.Id }).ToList();
            }
            return new Lecture()
            {
                DateTime = lecture.StartTime,
                itemName = lecture.itemName,
                Teacher = teacher,
                Subject = map(lecture.Subject),
                Grades = grades,
                Id = lecture.Id
            };
        }

        public static GradeDTO map(Grade grade, bool getRefernce)
        {
            return new GradeDTO()
            {
                Id = grade.ID,
                Value = grade.Value,
                StudentId = grade.Student.Id,
                LectureId = grade.Lecture.Id,

            };
        }
        public static Grade map(GradeDTO grade, bool getRefernce)
        {
            Student student;
            Lecture lecture;
            if (getRefernce)
            {
                student = map(grade.Student, false);
                lecture = map(grade.Lecture, false);
            }
            else
            {
                student = new Student() { Id = grade.Student.Id };
                lecture = new Lecture() { Id = grade.Lecture.Id };
            }
            return new Grade()
            {
                Value = grade.Value,
                Student = student,
                Lecture = lecture,
                ID = grade.Id
            };
        }

        public static SubjectDTO map(Subject subject)
        {
            return new SubjectDTO()
            {
                Title = subject.Title
            };
        }
        public static Subject map(SubjectDTO subject)
        {
            return new Subject()
            {
                Id = subject.Id,
                Title = subject.Title
            };
        }

        public static ScientificWorkDTO map(ScientificWork scientificWork)
        {
            return new ScientificWorkDTO()
            {
                Title = scientificWork.Title,
                SubjectId = scientificWork.Subject.Id,
                TeacherId = scientificWork.Teacher.Id,
                StudentId = scientificWork.Student.Id
            };
        }
        public static ScientificWork map(ScientificWorkDTO scientificWork, bool getReferance)
        {
            Subject subject;
            Student student;
            Teacher teacher;

            if (getReferance)
            {
                subject = map(scientificWork.Subject);
                student = map(scientificWork.Student, false);
                teacher = map(scientificWork.Teacher, false);
            }
            else
            {
                subject = new Subject() { Id = scientificWork.Subject.Id };
                student = new Student() { Id = scientificWork.Student.Id };
                teacher = new Teacher() { Id = scientificWork.Teacher.Id };
            }
            return new ScientificWork()
            {
                Id = scientificWork.Id,
                Title = scientificWork.Title,
                Subject = subject,
                Student = student,
                Teacher = teacher
            };
        }
    }
}
