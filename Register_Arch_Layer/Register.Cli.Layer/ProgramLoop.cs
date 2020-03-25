using System;
using System.Collections.Generic;
using System.Linq;
using Register.Cli.Layer.IoHelper;
using Register.Business.Layer;
using Register.Business.Layer.Dto;
using Register.Business.Layer.Service;


namespace Register.Cli.Layer
{
    public class ProgramLoop : IProgramLoop
    {
        public int SelectedCourse; // wybrany kurs id
        public long SelectedPesel; // wybrany student pesel
        public bool Succes;
        public string CommandLines; //Wpisana komenda -> menu glowne

        private readonly IRaportService _raportService;
        private readonly ICourseDayService _courseDayService;
        private readonly ICourseService _courseService;
        private readonly IHomeworkService _homeworkService;
        private readonly IStudentService _studentService;

        
       public ProgramLoop(IRaportService raportService, ICourseDayService courseDayService, ICourseService courseService,IHomeworkService homeworkService, IStudentService studentService)
        {
            _raportService = raportService;
            _courseDayService = courseDayService;
            _courseService = courseService;
            _homeworkService = homeworkService;
            _studentService = studentService;
            
        }

        public enum CommandType
        {
            SelectCourse,
            AddNewCourse,
            AddNewStudent,
            AddNewDay,
            AddNewHomework,
            EditStudent,
            EditCourse,
            CourseRaport,
            Exit
        }

        public delegate void MyDelegate();
        private static Dictionary<string, MyDelegate> commandDictionary = new Dictionary<string, MyDelegate>();

        public delegate void RaportIsPrintedEventHandler(object sender, RaportIsPrintedEventArgs eventArgs);
        public event RaportIsPrintedEventHandler RaportIsPrinted;

        public void Execute()
        {
            AddCommandsToDictionary();

            while (true)
            {
                ConsoleWriteHelper.CommandListText();

                Console.Write("Comand ");
                CommandLines = Console.ReadLine();

                if (commandDictionary.ContainsKey(CommandLines))
                {
                    foreach (var any in commandDictionary)
                    {
                        if (any.Key.Equals(CommandLines))
                        {
                            any.Value.Invoke();
                        }
                    }
                    CommandLines = "";
                }
                else
                {
                    while (!commandDictionary.ContainsKey(CommandLines))
                    {
                        ConsoleWriteHelper.CommandListText();
                        Console.WriteLine("Niewłaściwe polecenie!");
                        Console.Write("Wybierz dostepna komende: ");
                        CommandLines = Console.ReadLine();

                    }
                }
            }
        }

        private void SelectCourse()
        {
            bool exists;

            do
            {
                try
                {
                    SelectedCourse = ConsoleReadHelper.GetInt("Podaj Id kursu który na ktorym chcesz pracowac:  ");
                    exists = _courseService
                        .CheckIfCourseExistss(SelectedCourse); //jesli kurs istnieje to "true"
                    if (exists)
                    {
                        Console.WriteLine("Wybrano kurs o indeksie: " + SelectedCourse);
                    }
                    else
                    {
                        Console.WriteLine("Podany kurs - nie istnieje.\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("--Nie ma takiego kursu!\n");
                    throw;
                }

            } while (!exists);

            
        } //wybierz kurs 

        private void AddCommandsToDictionary()
        {

            commandDictionary.Add("SelectCourse", SelectCourse);
            commandDictionary.Add("AddNewCourse", AddNewCourse);
            commandDictionary.Add("AddNewStudent", AddNewStudent);
            commandDictionary.Add("AddNewDay", AddNewDayOfCourse);
            commandDictionary.Add("AddNewHomework", AddNewHomework);
            commandDictionary.Add("CourseRaport", CourseRaport);
            commandDictionary.Add("EditStudent", EditPersonalData);
            commandDictionary.Add("EditCourse", EditCourseInfo);
            commandDictionary.Add("Exit", ExitMethod);


        } //dodanie komend do slownika
        
        private bool CheckIfPeselExists()
        {
            var studentDto = new StudentDto();
           
            do
            {
                Succes = _studentService
                    .CheckIfClientPeselExists(studentDto.Pesel = ConsoleReadHelper.GetLong("Podaj Pesel: "));
                if (Succes)
                {
                    Console.WriteLine("Wprowadzony pesel, istnieje juz w bazie danych..\n");
                }

            } while (Succes);
            SelectedPesel = studentDto.Pesel;

            return true;
        } //metoda do sprawdzania czy pesel istnieje w bazie

        private void AddNewCourse()
        {
            var courseDto = new CourseDto();
            courseDto.CourseTitle = ConsoleReadHelper.GetCourseName("np: C#_SII_20170424_JB " + "/n Tytul kursu: ");
            courseDto.Teacher = ConsoleReadHelper.GetString("Nazwa prowadzacego: ");
            courseDto.DateStart = ConsoleReadHelper.GetDate("Data rozpoczecia: ");
            courseDto.HomeworkThreshold = ConsoleReadHelper.GetInt("Prog dla prac domowych[%]: ");
            courseDto.PresenceThreshold = ConsoleReadHelper.GetInt("Prog dla obecnosci[%]: ");
            int noStudent = ConsoleReadHelper.GetInt("Liczba Studentów: ");
            courseDto.StudentDtosList = new List<StudentDto>();

            var succes = false;
            int i = 0;

            do
            {
                //try
                //{
                    
                    var pesel = ConsoleReadHelper.GetLong("Podaj pesel studenta: ");
                   // var success = _courseService.CheckIfStudentExists(pesel);
                var success = _studentService.GetStudentByPesel(pesel);

                if (success!=null)
                    {
                        var students = _courseService.GetStudentFromDl(pesel);
                        //student jest w bazie więc mozna go dodać 
                        courseDto.StudentDtosList.Add(students);
                        i++;
                    }
                    //wróć do pętli i zapytaj jeszcze raz

               // }
               // catch (Exception e)
               // {
               //     Console.WriteLine("\nOsoba o podanym peselu, juz istnieje!!!\n");
               // }
            } while (i < noStudent);
            //   StudentDtoListToStudentList(StudentDtosList);
            _courseService.AddCourse(courseDto);
            succes = true;
            ConsoleWriteHelper.PrintOperationSuccessMessage(succes);

        } //dodaj kurs

        private void AddNewStudent()
        {

            var studentDto = new StudentDto();
            CheckIfPeselExists(); //sprawdz czy podany pesel istnieje w bazie
            studentDto.Pesel = SelectedPesel;
            studentDto.Name = ConsoleReadHelper.GetString("Imie: ");
            studentDto.Surname = ConsoleReadHelper.GetString("Nazwisko: ");
            studentDto.DateOfBirth = ConsoleReadHelper.GetDate("Data urodzin dd/mm/yyyy: ");
            studentDto.Sex = ConsoleReadHelper.GetSex("Kobieta = 1 / Mezczyzna = 2: \n Plec: ");

           
            var ifStudentWasAdd = _studentService.AddStudents(studentDto);
            if (!ifStudentWasAdd)
            {
                Console.Write("Dodano Studenta do bazy.\n\n");
            }
            else
            {
                Console.Write("Nie dadano studenta ponieważ ta osoba istnieje juz w bazie.\n\n");
            }


        } //dodaj studenta

        private void AddNewDayOfCourse()
        {
            while (SelectedCourse == 0)
            {
                Console.WriteLine("Nie wybrales kursu dla ktorego chcesz dodac dzien!\n");
                SelectCourse();
                //SelectedCourse = SelectCourse();
            } //sprawdzam czy zostal wybrany kurs dla ktorego chce sprawdzic obecnosc
            
            Console.Write("Lista obecnosci dla kursu: '" + SelectedCourse + "'" + "\n");

            var studentListFromCourse = _courseService.GetStudentListFromDl(SelectedCourse);
            foreach (var student in studentListFromCourse)
            {
                var courseDayDto = new CourseDayDto(); //tworze dzien kursu

                courseDayDto.Student = student;
                courseDayDto.Course = _courseService.GetCourseById(SelectedCourse); //pobranie kursu

                Console.Write(" obecny  = 1\n nieobecny = 0\n");
                var answer =
                    ConsoleReadHelper.GetInt("Czy " + student.Name + " " + student.Surname + " jest obecny?: ");

                if (answer == 1)
                {

                    courseDayDto.Present++;
                    courseDayDto.Allpresence++;
                    courseDayDto.Absent = 0;
                }
                else if (answer == 0)
                {
                    courseDayDto.Absent++;
                    courseDayDto.Allpresence++;
                    courseDayDto.Present = 0;
                }
                _courseDayService.AddNewDay(courseDayDto);
            }

            //metoda ktora wyciagnie ten kurs
        } //dodanie listy obecnosci na kursie

        private void AddNewHomework()
        {
            while (SelectedCourse == 0)
            {
                Console.WriteLine("Nie wybrales kursu dla ktorego chcesz dodac prace domowa!\n");
                SelectCourse();
                //SelectedCourse = SelectCourse();
            } //sprawdzam czy zostal wybrany kurs dla ktorego chce dodac prace domowa
            
            var homeworkDto = new HomeworkDto();
            
            Console.Write("-------Praca domowa dla kursu: '" + SelectedCourse + "'" + "--------\n");

            var studentListFromCourse = _courseService.GetStudentListFromDl(SelectedCourse);

            homeworkDto.MaxPoints = ConsoleReadHelper.GetInt("Maksymalna ilosc punktow do zdobycia z pracy domowej: ");

            foreach (var student in studentListFromCourse)
            {
                homeworkDto.Student = student;
                homeworkDto.Course = _courseService.GetCourseById(SelectedCourse); //pobranie kursu
                homeworkDto.StudentPoints =  ConsoleReadHelper.GetInt("Student " + student.Name + " " + student.Surname + " zdobył: ");

                _homeworkService.AddHomework(homeworkDto);
            }



        }//dodanie pracy domowej do kursu

        private void EditPersonalData()
        {
            Console.WriteLine("------Edycja danych personalnych-------\n");
            SelectedPesel = ConsoleReadHelper.GetLong("Podaj pesel dla którego chcesz zmienić dane: ");
            if (_studentService.CheckIfClientPeselExists(SelectedPesel)
            ) //check if pesel exists
            {
                StudentDto studentDto = new StudentDto();

                studentDto = _studentService.GetStudentByPesel(SelectedPesel);

                Console.WriteLine("\tUzupelnij pole, lub pozostaw puste jeśli nie chcesz edytować");

                studentDto.Pesel = SelectedPesel;
                Console.Write("Nowe imie: ");
                studentDto.Name = Console.ReadLine();
                Console.Write("Nowe nazwisko: ");
                studentDto.Surname = Console.ReadLine();
                Console.Write("Nowa data urodzenia: ");
                var date = Console.ReadLine();
                bool result = date.Any(x => !char.IsLetter(x)); //sprawdza czy w dacie znajduje się jakaś litera

                if (!String.IsNullOrEmpty(date) && !result)
                {
                    do
                    {
                        Console.WriteLine("Niepoprawny format.. Wpisz date poprawna date urodzenia, lub pozostaw pusta \n");
                        Console.WriteLine("Nowa data urodzenia[dd/mm/yyyy]: ");
                        date = Console.ReadLine();
                        result = date.Any(x => !char.IsLetter(x));

                    } while (!result && !String.IsNullOrEmpty(date));
                }

                if (!String.IsNullOrEmpty(date))
                {
                    try
                    {
                        studentDto.DateOfBirth = DateTime.Parse(date);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    finally
                    {
                        Console.WriteLine("Nie zmieniono daty, poniewaz wpisales zly format");
                    }
                }
                else
                {
                    studentDto.DateOfBirth = studentDto.DateOfBirth;
                }

               
                   Console.WriteLine("Podaj id kursu w ktorym ma zostać usunięty kursant:");
                   var courseId = Console.ReadLine();
              

                if (!String.IsNullOrEmpty(courseId))
                {
                    int id = int.Parse(courseId);
                    Succes = _courseService.RemoveStudentFromCourses(id, SelectedPesel);
                    if (Succes == true)
                    {
                        Console.WriteLine("Usunieto kursanta");
                    }
                    else
                    {
                        Console.WriteLine("Kursant nie zostal usuniety z kursu");
                    }
                }


                if (_studentService.ChangePersonalDataStudent(studentDto))
                {
                    Console.Clear();
                    Console.WriteLine("Zmieniono dane Studenta");
                }
                else
                {
                    Console.WriteLine("Nie zmieniono danych Studenta");
                }
                {

                }
            }
            else
            {
                Console.WriteLine("Pesel nie istnieje w bazie, edycja zakończona.\n");
            }

        } //medtoda do edycji danych klienta

        private void EditCourseInfo()
        {
            while (SelectedCourse == 0)
            {
                Console.WriteLine("Nie wybrales kursu, którego chcesz edytować!\n");
                SelectCourse();
                // SelectedCourse = SelectCourse();
            } //sprawdzam czy zostal wybrany kurs dla ktorego chce edytowac dane

            Console.Clear();

            Console.WriteLine("------ Edycja danych kursu o Id: {0} -------\n", SelectedCourse);

            Console.WriteLine("Uzupelnij pole, lub pozostaw puste jeśli nie chcesz edytować\n");

            CourseDto courseDto = new CourseDto();
            courseDto.Id = SelectedCourse;

            Console.Write("\tEdycja tytulu kursu: ");
            courseDto.CourseTitle = Console.ReadLine();
            Console.Write("\tEdycja prowadzacego: ");
            courseDto.Teacher = Console.ReadLine();

            Console.Write("\tEdycja progu zaliczenia pracy domowej: ");
            var homePts = Console.ReadLine();
            bool result = ConsoleReadHelper.IfAnyLetters(homePts); //sprawdza czy  znajduje się jakaś litera

            if ((!String.IsNullOrEmpty(homePts) && !result) )
            {
                do
                {
                    Console.WriteLine("Niepoprawny format punktow.. Wpisz date poprawna date urodzenia, lub pozostaw pusta \n");
                    Console.Write("Prog zaliczenia pracy domowej: ");
                    homePts = Console.ReadLine();
                    result = ConsoleReadHelper.IfAnyLetters(homePts);
                    if (result) //czy podano liczbe
                    {
                       var points = int.Parse(homePts);

                        if (!ConsoleReadHelper.BetweenRangeParcent(points))
                        {
                             result = false; //liczba z poza zakresu 0-100
                        }
                    }

                } while (!result && !String.IsNullOrEmpty(homePts));
            } //czy podano liczbe z zakresu 0-100


            if (!String.IsNullOrEmpty(homePts))
            {
                courseDto.HomeworkThreshold = int.Parse(homePts);
            }
            else
            {
                courseDto.HomeworkThreshold = courseDto.HomeworkThreshold;
            }





            Console.Write("\tEdycja progu zaliczenia obecnosci: ");
            var presencePts = Console.ReadLine();
            bool result2 = ConsoleReadHelper.IfAnyLetters(presencePts); //sprawdza czy  znajduje się jakaś litera

            if ((!String.IsNullOrEmpty(presencePts) && !result2))
            {
                do
                {
                    Console.WriteLine("Niepoprawny format.. Zmien wartosc, lub pozostaw pusta \n");
                    Console.Write("Prog zaliczenia obecnosci: ");
                    presencePts = Console.ReadLine();
                    result2 = ConsoleReadHelper.IfAnyLetters(presencePts);
                    if (result2) //czy podano liczbe
                    {

                        var parcent = int.Parse(presencePts);

                        if (!ConsoleReadHelper.BetweenRangeParcent(parcent))
                        {
                            result = false; //liczba z poza zakresu 0-100
                        }
                    }

                } while (!result && !String.IsNullOrEmpty(homePts));
            } //czy podano liczbe z zakresu 0-100

            if (!String.IsNullOrEmpty(presencePts))
            {
                courseDto.PresenceThreshold = int.Parse(presencePts);
            }
            else
            {
                courseDto.PresenceThreshold = courseDto.PresenceThreshold;
            }



                Console.WriteLine("Podaj pesel studenta w ktory ma zostać usunięty z kursu:");
                 var pesel = Console.ReadLine();


            if (!String.IsNullOrEmpty(pesel))
            {
                SelectedPesel = int.Parse(pesel);
                Succes = _courseService.RemoveStudentFromCourses(SelectedCourse,
                    SelectedPesel);
                if (Succes == true)
                {
                    Console.WriteLine("Usunieto kursanta");
                }
                else
                {
                    Console.WriteLine("Kursant nie zostal usuniety z kursu, poniewaz nie jest dodany do kursu");
                }
            }

            if (_courseService.ChangeCourseInfo(courseDto))
            {
                Console.Clear();
                Console.WriteLine("Zmieniono dane kursu o indeksie: {0}", SelectedCourse);
            }
            else
            {
                Console.WriteLine("Nie zmieniono danych kursu");
            }



        } //edycja kursu + usuniecie kursanta

        private void CourseRaport()
        {
            RaportIsPrinted += ExportRaport;//sub na event

            while (SelectedCourse == 0)
            {
                Console.WriteLine("Nie wybrales kursu dla ktorego chcesz dodac dzien!\n");
                SelectCourse();
                //SelectedCourse = SelectCourse();
            } //sprawdzam czy zostal wybrany kurs dla ktorego chce wydrukowac raport


            //Przygotowanie danych o kursie
            var course = _courseService.GetCourseById(SelectedCourse);


            Console.WriteLine("---------RAPORT---------\n");
            Console.WriteLine("Nazwa kursu: " + course.CourseTitle + "\n");
            Console.WriteLine("Data rozpoczecia: " + course.DateStart + "\n");
            Console.WriteLine("Prog z pracy domowej: " + course.HomeworkThreshold + "\n");
            Console.WriteLine("Prog z obecnosci: " + course.PresenceThreshold + "\n");


            //Przygotowanie pliku JSON
            RaportDto raportDto = new RaportDto(); //json
            raportDto.CourseName = course.CourseTitle;//json
            raportDto.CourseDateOfStart = course.DateStart;//json
            raportDto.HomeworkThreshold = course.HomeworkThreshold;//json
            raportDto.PresenceThreshold = course.PresenceThreshold;//json
            raportDto.TextPresence = "--Obecnosc--";//json
            raportDto.TextHomework = "--Praca Domowa--";//json


            var studentListFromCourse = _courseService.GetStudentListFromDl(SelectedCourse); //pobranie listy studentow uczestniczacych w kursie

            Console.WriteLine("--Obecnosc--\n"); 
            foreach (var student in studentListFromCourse)
            {
                //Przygotowanie danych o obecnosci
                var courseDayStudent = _courseDayService.GetCourseDayByIds(student.Id, SelectedCourse); //Pobranie obecnosci dla studenta z danego kursu
                var parcent = _raportService.CheckHowManyParcent(courseDayStudent.Allpresence,courseDayStudent.Present); //Przeliczenie wyniku obecnosci na procenty
                var passOrFail = _raportService.CheckIfResultsIsHigherThanThreshold(parcent, course.PresenceThreshold); //Sprawdzenie czy wynik jest wyższy od progu zaliczenia

                //Wydruk
                Console.Write(student.Name + " " + student.Surname + " " + courseDayStudent.Present + "/" + courseDayStudent.Allpresence);
                Console.Write(" " + "(" + parcent + "%" + ")" + "  -" + passOrFail + "\n");



                string presencePerStudent = student.Name + " " + student.Surname + " " + courseDayStudent.Present + "/" +
                                         courseDayStudent.Allpresence + " " + "(" + parcent + "%" + ")" + "  -" + passOrFail; // json
                raportDto.PresenceList.Add(presencePerStudent);//json

            }

            Console.WriteLine("\n--Praca Domowa--\n");
            foreach (var student in studentListFromCourse)
            {
                //Przygotowanie danych o pracy domowej
                var homeworkStudent = _homeworkService.GetHomeworkByIds(student.Id, SelectedCourse); //Pobranie prac domowych dla studenta
                var parcent = _raportService.CheckHowManyParcent(homeworkStudent.MaxPoints, homeworkStudent.StudentPoints);//Przeliczenie wyniku obecnosci na procenty
                var passOrFail = _raportService.CheckIfResultsIsHigherThanThreshold(parcent, course.HomeworkThreshold); //Sprawdzenie czy wynik jest wyższy od progu zaliczenia

                //Wydruk
                Console.Write(student.Name + " " + student.Surname + " " + homeworkStudent.StudentPoints + "/" + homeworkStudent.MaxPoints);
                Console.Write(" " + "(" + parcent + "%" + ")" + " -" +  passOrFail + "\n");

               
                string homeworkPerStudents = student.Name + " " + student.Surname + " " +homeworkStudent.StudentPoints + "/" + homeworkStudent.MaxPoints + " " + "(" + parcent + "%" + ")" + " -" + passOrFail; // json
                raportDto.HomeworkList.Add(homeworkPerStudents);//json

            }

            raportDto.TeacherName = course.Teacher;
            OnCourseRaportPrinted(raportDto);
            //  ExportRaport(raportDto);//json bez trzeciego zadania - zwykly zapis do pliku




        } //drukuje raport z wybranego kursu

        private void OnCourseRaportPrinted(RaportDto raportDto)
        {
            if (RaportIsPrinted == null)
            {
                return;
            }
            RaportIsPrintedEventArgs raportIsPrintedEventArgs = new RaportIsPrintedEventArgs();
            raportIsPrintedEventArgs.RaportDto = raportDto;

            RaportIsPrinted(this, raportIsPrintedEventArgs);   


        } //event na drukowanie raportu

        private void ExportRaport(object sender, RaportIsPrintedEventArgs raportIsPrintedEventArgs)
        {
            string fileName = ConsoleReadHelper.GetString("Podaj nazwe pliku, w ktorym ma zostac zapisany plik raportu: ");
            fileName += ".json";
            _raportService.ExportRaportToFile(fileName, raportIsPrintedEventArgs.RaportDto);


        } //eksportowanie pliku

        private void ExitMethod()
        {
            Environment.Exit(0);
        } //wylaczenie aplikacji

    }
}
