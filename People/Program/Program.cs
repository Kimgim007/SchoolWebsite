using People.EntityAndService.Entity;
using People.EntityAndService.Service;
using System;
using System.Collections.Generic;
namespace People
{
    internal class Program
    {
        static string[] maleNames = new string[] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "Oliver ", "Jack ", "Harry ", "Jacob ", "Charley ", "Thomas ", "George ", "Oscar ", "James ", "William ", "Noah ", "Liam ", "Mason ", "Ethan ", "Michael ", "Alexander", "Daniel" };
        static string[] femaleNames = new string[] { "abby", "abigail", "adele", "adrian", "Emma", "Olivia", "Ava", "Sophia", "Isabella", "Mia", "Charlotte", "Abigail", "Emily", "Harper", "Lola", "Lillian", "Lucy", "Stella", "Genevieve", "Cora", "Evelyn", "Clara", "Ruby", "Eva " };

        static string[] HigherMathematics = new string[] { "Теория чисел", "Геометрия", "Алгебра", "Исчисление и анализ", "Дискретная математика", "Математическая логика и теория множеств", "Прикладная математика", "Статистика и другие науки, принимающие решения", "Вычислительная математика" };
        static string[] AppliedPhysics = new string[] { "Классическая механика", "Термодинамика и статистическая механика", "Электромагнетизм и фотоника", "Релятивистская механика", "Квантовая механика, атомная физика и молекулярная физика", "Оптика и акустика", "Физика конденсированных сред", "Физика частиц высоких энергий и ядерная физика", "Космология", "Междисциплинарные области", "Краткие сведения" };
        static string[] OrganicChemistry = new string[] { "Агрохимия", "Аналитическая химия ", "Астрохимия", "Биохимия", "Вычислительная химия", "Зелёная химия", "Квантовая химия", "Коллоидная химия ", "Компьютерная химия", " Кристаллохимия", "Математическая химия", "Материаловедение", "Медицинская химия", "Нанотехнология" };

        static void Main(string[] args)
        {
            ScientificWorkService scientificWorkService = new ScientificWorkService();
            StudentService serviceForStudent = new StudentService();
            TeacherService serviceForTeache = new TeacherService();
            LectureService seviceForLecture = new LectureService();
            SubjectService subjectService = new SubjectService();
            GradeSevice gradeSevice1 = new GradeSevice();
            

            Grade serviceGrade = new Grade();
            Console.WriteLine("Если вы хотите создать ученика ,преподавателя или сгенерировать лекцию , введите Yes если нет нажмите Enter");
            string answer = Console.ReadLine();
            while (answer == "Yes" || answer=="yes")
            {
                Console.WriteLine("1.Создать своего ученика ");
                Console.WriteLine("2.Создать лучайно сгенерированных учеников");
                Console.WriteLine("3.Создать своего преподавать  ");
                Console.WriteLine("4.Создать лучайно сгенерированных преподавателей");
                Console.WriteLine("5 Генерация расписания");
                Console.WriteLine("6 Добавить Subject");
                Console.WriteLine("7 Добавить научную работу");
                answer = Console.ReadLine();

                string yesOrNo = "Yes";

                switch (answer)
                {
                    case "1":
                        {
                            while (yesOrNo == "Yes"||yesOrNo =="yes")
                            {
                                serviceForStudent.AddStudent(CreateStudentManualy());
                                Console.WriteLine("Хотите создать ещё одного ученика Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }
                            break;
                        }
                    case "2":
                        {
                            while(yesOrNo == "Yes" || yesOrNo == "yes")
                            {
                                Console.WriteLine("Сколько случайно сгенерированных учеников вы хотите");
                                int howManyStudents = Int32.Parse(Console.ReadLine());

                                for (int i = 0; i < howManyStudents; i++)
                                {
                                    serviceForStudent.AddStudent(StudentGeneration());

                                }
                                Console.WriteLine("Хотите ещё раз сгенерировать учеников Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }
                         
                            break;

                        }
                    case "3":
                        {
                            while (yesOrNo == "Yes"||yesOrNo=="yes")
                            {
                                serviceForTeache.AddTeacher(MakeATeacher());
                                Console.WriteLine("Хотите создать ещё одного ученика Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }
                            break;

                        }
                    case "4":
                        {
                            while (yesOrNo == "Yes" || yesOrNo == "yes")
                            {
                                Console.WriteLine("Сколько преподавателей вы хотите сгенерировать ?");
                                int howManyTeahsets = Int32.Parse(Console.ReadLine());

                                for (int i = 0; i < howManyTeahsets; i++)
                                {
                                    serviceForTeache.AddTeacher(TeacherGeneration());
                                }
                                Console.WriteLine("Хотите сгенерировать ещё  преподавателя Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }
                               
                            break;
                        }
                    case "5":
                        {
                            while (yesOrNo == "Yes" || yesOrNo == "yes")
                            {
                                StudentService studentService = new StudentService();
                                LectureService lectureServive = new LectureService();
                                List<Student> students = studentService.GetStudents();
                                GradeSevice gradeSevice = new GradeSevice();
                                Random random = new Random();
                                Lecture lecture = new Lecture();
                                Console.WriteLine("Сколько пар сгенерировать ?");
                                int howManyLectureGenetation = Int32.Parse(Console.ReadLine());
                                for (int i = 0; i < howManyLectureGenetation; i++)
                                {
                                    LectureGeneration();
                                    foreach (Student student in students)
                                    {
                                        gradeSevice.AddGrade(new Grade(random.Next(4, 11), student, lectureServive.GetLastLecture()));
                                    }
                                }
                                Console.WriteLine("Хотите сгенерировать ещё лекий Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }

                            break;
                        }
                    case "6":
                        {
                            while (yesOrNo =="Yes"||yesOrNo == "yes")
                            {
                                Console.WriteLine("Какой Subject вы хоите добавить ?");
                                string name = Console.ReadLine();
                                subjectService.AddSubject(new Subject(name));
                                Console.WriteLine("Хотите ещё ещё раз содать Subject Yes или No?");
                                yesOrNo = Console.ReadLine();
                            }
                         
                            break;
                        }
                    case "7":
                        {
                            while(yesOrNo == "yes" || yesOrNo == "Yes")
                            {
                                Console.WriteLine("Как будет называться науная работа ?");
                                string Title = Console.ReadLine();
                                Console.WriteLine("По какому предмету она будет написана");
                                Console.WriteLine(string.Join("\n", subjectService.GetSubjects()));
                                Console.WriteLine("Какой преподаватель будеть курировать ? Введите ID");
                               Subject subject = subjectService.GetSubject(Int32.Parse(Console.ReadLine()));
                                Console.WriteLine(string.Join("\n", serviceForTeache.GetTeachers()));
                                Teacher teacher = serviceForTeache.GetTeacher(Int32.Parse(Console.ReadLine()));
                              Console.WriteLine("Кто из учеников будет её писать ? Введите ID");
                                Console.WriteLine(string.Join("\n", serviceForStudent.GetStudents()));
                                Student student = serviceForStudent.GetStudent(Int32.Parse(Console.ReadLine()));
                                scientificWorkService.AddScientificWork(new ScientificWork(Title, subject, teacher, student));
                            }
                            break;
                        }
                        
                }
                Console.WriteLine("Хотите ещё кого нибудь создать или сгенерировать , Yes or No?");
                answer = Console.ReadLine();
            }
            string cycle = "Yes";
            string action;

            while (cycle == "Yes"|| cycle == "yes")
            {
                Console.WriteLine("1.Методы работы с учениками");
                Console.WriteLine("2.Методы работы с преподавателями");
                Console.WriteLine("3.Методы работы с лекциями");
                Console.WriteLine("4 Методы работы с научными работами");

                action = Console.ReadLine();
                if (action == "1")
                {
                    Console.WriteLine("Какое из действий вы хотите выбрать");
                    Console.WriteLine("1.Показать студента с самым высоким средним баллом ");
                    Console.WriteLine("2.Показать студента с самым низким средним баллом");
                    Console.WriteLine("3.Отсортировать студентов по именам ");
                    Console.WriteLine("4.Отсорировать студентов по полу ");
                    Console.WriteLine("5.Отсортировать студентов по возрасту ");
                    Console.WriteLine("6.Хотите ли вы узнать кто учится лучше, девочки или мальчики ");
                    Console.WriteLine("7.Хотите ли вы узнать средний возраст по группе?");
                    Console.WriteLine("8 Хотите ли вы узнать среднюю оценку у мальчиков и у девочек");
                    Console.WriteLine("9 Группировка студентов по первой букве");                 
                    Console.WriteLine("11 Удалить студента");
                    Console.WriteLine("12.Узнать среднюю оценку за предмет");
                    Console.WriteLine("13 Найти студента по ID");
                    Console.WriteLine("14 Полная информация о студенте");
                    Console.WriteLine("15 Науная работа у этого студента");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            {
                                Console.WriteLine(serviceForStudent.StudetnHoHaveMaxMark());

                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine(serviceForStudent.StudetnHoHaveLowMark());
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine(string.Join("\n", serviceForStudent.SortingByName()));
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine(string.Join("\n", serviceForStudent.SortingByGender()));
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine(string.Join("\n", serviceForStudent.SortingByAge()));
                                break;
                            }
                        case "6":
                            {
                                Console.WriteLine(serviceForStudent.WhoStudiesBetter());
                                break;
                            }
                        case "7":
                            {
                                Console.WriteLine(serviceForStudent.AverageAgeByGroup());
                                break;
                            }
                        case "8":
                            {
                                Console.WriteLine(serviceForStudent.AverageScoreForBoysAndGirls());
                                break;
                            }
                        case "9":
                            {
                                //Console.WriteLine(serviceForStudent.GrupStudetsByFirstWord();
                                var groupStudentList = serviceForStudent.GrupStudetsByFirstWord();
                                foreach (var groupByFirstLetter in groupStudentList)
                                {
                                    Console.WriteLine(groupByFirstLetter.Key);
                                    foreach (var studenFromGrupp in groupByFirstLetter)
                                    {
                                        Console.WriteLine(studenFromGrupp.ToString());
                                    }
                                }
                                break;
                            }         
                        case "11":
                            {
                                Console.WriteLine(string.Join("\n", serviceForStudent.GetStudents()));
                                Console.WriteLine();
                                Console.WriteLine("Введите номер ученика которого хотите удалить");
                                int num = Int32.Parse(Console.ReadLine());
                                serviceForStudent.Remove(num);
                                Console.WriteLine();
                                Console.WriteLine(string.Join("\n", serviceForStudent.GetStudents()));
                                break;
                            }
                        case "12":
                            {
                                Console.WriteLine("Выберите ученика ");
                                Console.WriteLine(string.Join("\n", serviceForStudent.GetStudents()));
                                int num = Int32.Parse(Console.ReadLine());
                                Student student = serviceForStudent.GetStudent(num);
                                Console.WriteLine("По какому подразделу вы хотите знать его средюю оценку");
                                foreach(var item in HigherMathematics)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                foreach (var item in AppliedPhysics)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                foreach (var item in OrganicChemistry)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                string name = Console.ReadLine();
                                if(student.AverageMarkForSubject(name) == null)
                                {
                                    Console.WriteLine($"Такого предмета у студента нет");
                                }
                                else
                                {
                                    Console.WriteLine(student.AverageMarkForSubject(name));
                                }
                            
                                break;
                            }
                        case "13":
                            {
                                Console.WriteLine("Введите ID студента");
                                int num = Int32.Parse(Console.ReadLine());
                                Student student = serviceForStudent.GetStudent(num);
                                Console.WriteLine(student);
                                break;
                            }
                        case "14":
                            {
                                Console.WriteLine("О каком студенте вы хотите знать информацию , введите его Id");
                                Console.WriteLine(string.Join("\n",serviceForStudent.GetStudents()));
                                int num = Int32.Parse(Console.ReadLine());
                                Student student = serviceForStudent.GetStudent(num);
                                Console.WriteLine();
                                Console.WriteLine(string.Join("\n", student.Grades));
                                Console.WriteLine();
                               
                                break;
                            }
                        case "15":
							{
                                Console.WriteLine("Выберите ученика ");
                                Console.WriteLine(string.Join("\n", serviceForStudent.GetStudents()));
                                int num = Int32.Parse(Console.ReadLine());
                                Student student = serviceForStudent.GetStudent(num);
                                Console.WriteLine(student.ScientificWork);
                                break;
							}
                    }
                }
                else if (action == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("1.Все ли преподаватели старше 30 лет");
                    Console.WriteLine("2.Есть ли преподаватели младше 30;");
                    Console.WriteLine("3.Есть ли преподаватель кторому 30 лет ровно");
                    Console.WriteLine("4.Кол-во преподавателей которым от 30 до 35");
                    Console.WriteLine("5.Найти первого преподавателя который старше 30 лет");
                    Console.WriteLine("6.Сгруппировать преподавателей по возрасту");
                    Console.WriteLine("7.Последний преподаватель которому 30 лет");
                    Console.WriteLine("8.Вывод списка преподавателей пропустив первых 5");
                    Console.WriteLine("9.Вывести первых 5 преподователей");                   
                    Console.WriteLine("11 Сгруппировать по зарплате преподавателей , по соткам");
                    Console.WriteLine("12 Поменять имя преподавателя");
                    Console.WriteLine("13.Расписание пар у преподавателя");
                    Console.WriteLine("14 Поиск преподавателя по ID");
                    Console.WriteLine("15 Науная работа у препода");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            {
                                Console.WriteLine(serviceForTeache.AreAllTeachersOver30());
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine(serviceForTeache.AreThereAnyTeachersUnder30());
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine(serviceForTeache.IsThereATeacherWhoIs30YearsOldExactly());
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine(string.Join("\n", serviceForTeache.NumberOfTeachersWhoAreFrom30To35()));
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine(serviceForTeache.TheFirstTeacherWhoIsOver30YearsOld());
                                break;
                            }
                        case "6":
                            {
                                var grupTheacherList = serviceForTeache.GroupTeachersByAge();
                                foreach (var grupByAge in grupTheacherList)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(grupByAge.Key);

                                    foreach (var teacherFromGrup in grupByAge)
                                    {
                                        Console.WriteLine(teacherFromGrup.ToString());
                                    }
                                }
                                break;
                            }
                        case "7":
                            {
                                var teacherGrup = serviceForTeache.TheLastTeacherWhoIs30YearsOld();

                                break;
                            }
                        case "8":
                            {
                                Console.WriteLine(string.Join("\n", serviceForTeache.OutputOfTheListOfTeachersSkippingTheFirst5()));
                                break;
                            }
                        case "9":
                            {
                                Console.WriteLine(string.Join("\n", serviceForTeache.EnterFirstFiveTeachers()));
                                break;

                            }
                        case "10":
                            {
                                var grupTeacherList = serviceForTeache.GrupTeachersByMoth();
                                foreach (var gropByFirsMonth in grupTeacherList)
                                {
                                    foreach (var teacherFromGrup in gropByFirsMonth)
                                    {
                                        Console.WriteLine(teacherFromGrup.ToString());
                                    }
                                }
                                break;
                            }
                        case "11":
                            {
                                var teacherList = serviceForTeache.GrupTeachersByFirstZP();
                                foreach (var teacherKey in teacherList)
                                {
                                    foreach (var teacherGrup in teacherKey)
                                    {
                                        Console.WriteLine(teacherGrup.ToString());
                                    }
                                }
                                break;
                            }
                        case "12":
                            {
                                Console.WriteLine(string.Join("\n", serviceForTeache.GetTeachers()));
                                Console.WriteLine();
                                Console.WriteLine("Введите номер преподавателя чьё имя вы хотите поменять , номер первого студента 1");
                                Teacher teacher = serviceForTeache.GetTeacher(Int32.Parse(Console.ReadLine()));
                                Console.WriteLine("Введите новое имя");
                                teacher.Name = Console.ReadLine();
                                serviceForTeache.UpdateTeacher(teacher);
                                Console.WriteLine();
                                Console.WriteLine(string.Join("\n", serviceForTeache.GetTeachers()));
                                break;
                            }
                        case "13":
                            {
                                Console.WriteLine("Выберете преподавателя у которого хотите узнать расписание");
                                Console.WriteLine(string.Join("\n", serviceForTeache.GetTeachers()));
                                int num = Int32.Parse(Console.ReadLine());
                                Teacher teacher = serviceForTeache.GetTeacher(num);
                                Console.WriteLine();
                                var lectureTime = teacher.LectureCount();
                                foreach(var item in lectureTime)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(item.Key.ToShortDateString());
                                    foreach (var item2 in item)
                                    {
                                        Console.WriteLine(item2.Subject.ToString());
                                    }
                                }
                                break;
                            }
                        case "14":
                            {
                                Console.WriteLine("Введите ID преподавателя");
                                int num = Int32.Parse(Console.ReadLine());
                                Teacher teacher = serviceForTeache.GetTeacher(num);
                                Console.WriteLine(teacher);
                                break;
                            }
                        case "15":
                            {
                                Console.WriteLine("Выберите преподавателя ");
                                Console.WriteLine(string.Join("\n",serviceForTeache.GetTeachers()));
                                int num = Int32.Parse(Console.ReadLine());
                                Teacher teacher = serviceForTeache.GetTeacher(num);
                                Console.WriteLine(teacher.scientificWorks);
                                break;
                                
                            }
                    }
                }
                else if (action == "3")
                {
                    Console.WriteLine("1 Показать все лекции ");

                    Console.WriteLine("3 Показать лекцию по ID");
                    Console.WriteLine("4 Показать оценки за эту лекцию");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            {
                                Console.WriteLine(string.Join("\n", seviceForLecture.GetLectures()));
                                break;
                            }

                        case "3":
                            {
                                Console.WriteLine("Введите ID лекции");
                                int num = Int32.Parse(Console.ReadLine());
                                Lecture lecture = seviceForLecture.GetLecture(num);
                                Console.WriteLine(lecture);
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Вывести оценки за лекцию");
                                Console.WriteLine("Ввести Id");
                                int num = Int32.Parse(Console.ReadLine());
                                var lecture = seviceForLecture.GetLecture(num);
                                foreach(var item in lecture.Grades)
                                {
                                    Console.WriteLine($"{item.Value} - {serviceForStudent.GetStudent(item.Student.Id)}");
                                }
                                var grades = lecture.Grades;
                                
                                Console.WriteLine();
                                break;
                            }
                    }
                }
                else if (action == "4")
                {
                    Console.WriteLine("1.Показать научные работы");
                    Console.WriteLine("2 Найти научную работу по Id");
                    action= Console.ReadLine();
                    switch(action)
                    {
                        case "1":
                            {
                                Console.WriteLine((string.Join("\n", scientificWorkService.GetScientificWorks())));
                                break;
                            }
                            case"2":
                            {
                                Console.WriteLine("Какую научную работу вы хотите найти?");
                                int num = Int32.Parse(Console.ReadLine());
                                Console.WriteLine(scientificWorkService.GetScientificWork(num));
                                break;
                            }
                    }
                }
             
                Console.WriteLine();

                Console.Write("Если хотите повторить введите  'Yes' , если хотите закончить введите 'No'");

                cycle = Console.ReadLine();
                Console.Clear();
            }
        }
        public static Teacher TeacherGeneration()
        {

            Random random = new Random();

            string GenerationOfDatesOfBirth = random.Next(1, 29).ToString() + "." + random.Next(1, 13).ToString() + "." + random.Next(1960, 2000).ToString();

            

            if (random.Next(0, 2) == 0)
            {
                return (new Teacher(femaleNames[random.Next(0, femaleNames.Length)], GenerationOfDatesOfBirth, "f", random.Next(400, 1000).ToString()));

            }
            else
            {
                return (new Teacher(maleNames[random.Next(0, maleNames.Length)], GenerationOfDatesOfBirth, "m", random.Next(400, 1000).ToString()));
            }

        }
        public static Student CreateStudentManualy()
        {
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату своего рожденья , например 01.01.2000");
            string birthday = Console.ReadLine();
            Console.WriteLine("Введите пол , например male or female , m or f");
            string gender = Console.ReadLine();
            return new Student(name, birthday, gender);

        }
        public static Student StudentGeneration()
        {
            string[] maleNames = new string[] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "Oliver ", "Jack ", "Harry ", "Jacob ", "Charley ", "Thomas ", "George ", "Oscar ", "James ", "William ", "Noah ", "Liam ", "Mason ", "Ethan ", "Michael ", "Alexander", "Daniel" };
            string[] femaleNames = new string[] { "abby", "abigail", "adele", "adrian", "Emma", "Olivia", "Ava", "Sophia", "Isabella", "Mia", "Charlotte", "Abigail", "Emily", "Harper", "Lola", "Lillian", "Lucy", "Stella", "Genevieve", "Cora", "Evelyn", "Clara", "Ruby", "Eva " };

            Random random = new Random();

            string GenerationOfDatesOfBirth = random.Next(1, 29).ToString() + "." + random.Next(1, 13).ToString() + "." + random.Next(1999, 2003).ToString();

            if (random.Next(0, 2) == 0)
            {

                return new Student(femaleNames[random.Next(0, femaleNames.Length)], GenerationOfDatesOfBirth, "f");

            }
            else
            {

                return new Student(femaleNames[random.Next(0, femaleNames.Length)], GenerationOfDatesOfBirth, "m");

            }
        }
        public static Teacher MakeATeacher()
        {
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату своего рожденья , например 01.01.2000");
            string birthday = Console.ReadLine();
            Console.WriteLine("Введите пол , например male or female , m or f");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите свою зарплату оценка ,например 1000");
            string avarageMark = Console.ReadLine();
            return (new Teacher(name, birthday, gender, avarageMark));

        }
        public static void LectureGeneration()
        {
            Random random = new Random();

            TeacherService serviceForTeache = new TeacherService();
            LectureService lectureServive = new LectureService();
            SubjectService subjectServive = new SubjectService();
            List<Teacher> teachers = serviceForTeache.GetTeachers();

            //Пары начинаются в 9 утра их 6 штук заканчиваются в 18
            var date = DateTime.Today.AddHours(9);


            var endTimeOfPairs = 18;
            var durationLecture = 1.5;



            var dateTryTime = lectureServive.GetMaxTimeLecture();
            if (dateTryTime.Hour >= endTimeOfPairs)
            {
                date = dateTryTime.AddDays(1);
                date = date.AddHours(-9);
            }
            else
            {
                date = lectureServive.GetMaxTimeLecture();
                date = date.AddHours(durationLecture);
            }


            switch (random.Next(0, 3))
            {
                case 0:
                    {

                        lectureServive.AddLecture(new Lecture(subjectServive.GetSubject(1), date, HigherMathematics[random.Next(0, HigherMathematics.Length - 1)], teachers[random.Next(0, teachers.Count)]));
                        break;
                    }
                case 1:
                    {

                        lectureServive.AddLecture(new Lecture(subjectServive.GetSubject(2), date, AppliedPhysics[random.Next(0, HigherMathematics.Length - 1)], teachers[random.Next(0, teachers.Count)]));
                        break;
                    }
                case 2:
                    {

                        lectureServive.AddLecture(new Lecture(subjectServive.GetSubject(3), date, OrganicChemistry[random.Next(0, HigherMathematics.Length - 1)], teachers[random.Next(0, teachers.Count)]));
                        break;
                    }
                default:
                    {
                        throw new Exception("О нет , что то пошло не так!!!!!!!!!!!!!!!!!!!!!!");
                    }
            }
        }
    }
}

