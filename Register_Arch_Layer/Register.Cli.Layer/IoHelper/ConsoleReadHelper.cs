using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Register.Cli.Layer.IoHelper
{
    public class ConsoleReadHelper
    {

        public static ProgramLoop.CommandType GetCommnadType()
        {
            ProgramLoop.CommandType commandType;
            Console.WriteLine("|------------------DZIENNIK ZAJEĆ------------------|\n" +
                              "\t\t\t\tmade by Jakub Gerlee \n" +
                              "\nSelectCourse - Wybierz kurs" +
                              "\nAddNewCourse - Stworz kurs" +
                              "\nAddNewStudent - Dodanie nowego studenta" +
                              "\nAddNewDay - Dodanie dnia kursu" +
                              "\nAddNewHomework - Dodanie nowej pracy domowej" +
                              "\nCourseRaport - Raport kursu" +
                              "\nEditStudent - Edycja danych studenta" +
                              "\nEditCourse - Edycja danych kursu" +
                              "\nExit - Wyjscie z aplikacji\n\n");


            while (!Enum.TryParse(Console.ReadLine(), out commandType))
            {
                Console.WriteLine("Wprowadzono nieprawidlowy znak, spróbuj ponownie...\n");

                Console.WriteLine("|------------------DZIENNIK ZAJEĆ------------------|\n" +
                                  "\t\t\t\tmade by Jakub Gerlee \n" +
                                  "\nSelectCourse - Wybierz kurs" +
                                  "\nAddNewCourse - stworz kurs" +
                                  "\nAddNewStudent - Dodanie nowego studenta" +
                                  "\nAddNewDay - Dodanie dnia kursu" +
                                  "\nAddNewHomework - Dodanie nowej pracy domowej" +
                                  "\nCourseRaport - Raport kursu" +
                                  "\nEditStudent - Edycja danych studenta" +
                                  "\nEditCourse - Edycja danych kursu" +
                                  "\nExit - Wyjscie z aplikacji\n\n");
            }

            return commandType;
        } //Pobiera komende od uzytkownika


        public static string GetCourseName(string message) //Sprawdza czy podany typ jest String
        {
            
            
            while (true)
            {
                Console.Write(message);
                var courseName = Console.ReadLine();
                CheckIsCourseNameCorrect(courseName);

                while (String.IsNullOrEmpty(courseName) || !CheckIsCourseNameCorrect(courseName))

                {
                    Console.Write("Nic nie wpisales, lub wpisales niepoprawny format..\n\n");
                    Console.Write(message);


                    courseName = Console.ReadLine();
                }
                return courseName;

            }
        }

        public static bool CheckIsCourseNameCorrect(string courseName)
        {
            Regex sample = new Regex("^(C#_)(\\w+)_([A-Z]{2})$");
            var courseNameCorrect = sample.IsMatch(courseName);
            return courseNameCorrect;
        }

        public static int GetInt(string message)
        {
            int number;
            Console.Write(message);

            while (!Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Podana liczba jest niepoprawna...\n");
                Console.Write("Wpisz poprawna komende: ");
            }

            return number;
        } //Parsuje na int

        public static int GetIntDo(string message)
        {
            int number = 0;
            Console.Write(message);
           number = Int32.Parse(Console.ReadLine());
            

            return number;
        } //Parsuje na int

        public static long GetLong(string message)
        {
            long number;
            Console.Write(message);

            while (!long.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Podana liczba jest nieprawidlowego typu, sprobuj ponownie: ");
            }

            return number;
        } //Parsuje na long

        public static DateTime GetDate(string message)
        {
            DateTime dateTime;
            Console.Write(message);

            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.Write("Podales niepoprawna wartosc..\n\n");
                Console.Write(message);
            }

            return dateTime;
        } //Pobiera DateTime w prawidłowym formacie

        public static string GetString(string message) //Sprawdza czy podany typ jest String
        {
 
            while (true)
            {
                Console.Write(message);
                var variable = Console.ReadLine();
                while(String.IsNullOrEmpty(variable))
                {
                    Console.Write("Nic nie wpisales..\n\n");
                    Console.Write(message);
                    

                    variable = Console.ReadLine();
                }
                return variable;

            }
        }

        public static string GetStringAnswer(string message) //Sprawdza czy podany typ jest String
        {

            while (true)
            {
                Console.Write(message);
                var variable = Console.ReadLine();
                while (String.IsNullOrEmpty(variable) && variable != "t" && variable != "T" && variable != "n" && variable != "N")
                {
                    Console.Write("Nic nie wpisales..\n\n");
                    Console.Write(message);


                    variable = Console.ReadLine();
                }
                return variable;

            }
        }
        
        public static int GetSex(string message)
        {
            Console.Write(message);
            while (true)
            {

                int number;
                while (!Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number == 1 || number == 2 )
                    {
                        return number;
                    }

                    Console.WriteLine("Podana liczba jest niepoprawna...\n");
                    Console.Write(message);

                }

                return number;

            }
        }

        public static bool IfAnyLetters(string str)
        {
            bool result = str.Any(x => !char.IsLetter(x));

            return result;
        } //sprawdza czy w stringu sa jakies liczby

        public static bool BetweenRangeParcent(int number)
        {
            if(number>100 || number < 0)
            {
                Console.WriteLine("Liczba z poza zakresu 0-100..");

                return false; //liczba z poza zakresu
            }
            return true; //liczba pomiedzy 0-100
        } //sprawdza czy podana liczba jest miesci sie pomiedzy 0-100

    } 

    
}
