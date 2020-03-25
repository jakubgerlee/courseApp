using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ApplicationToReadingJsonFile
{
    internal class ProgramLoop
    {
        public static void Execute()
        {
            Instruction();
            var filePath = GetFilePath();
            //do testów, zakomentuj powyzsza linijke
            //var filePath = @"C:\Users\muczo\Desktop\Homework\homeeeev\homework_iii\jsonPliki\dobryplik.json";
            var raport = LoadJson(filePath);
            WriteRaport(raport);
        }
        
        internal static void Instruction()
        {
            Console.Write("--------Aplikacja do odczytu pliku JSON--------\n\n\n");
            
        } //instrukcja obslugi aplikacji
        
        internal static string GetFilePath()
        {
            string filePath;
            do
            {
                Console.WriteLine("Podaj sciezke do pliku json, ktory chcesz odczytac: ");
                filePath = Console.ReadLine();
            } while (string.IsNullOrEmpty(filePath));
            return filePath;
        } //pobieranie ścieżki do pliku

        internal static Json LoadJson(string filePath)
        {
            using (StreamReader File = new StreamReader(filePath))
            {
                
                string json = File.ReadToEnd();
                var jsonFile =JsonConvert.DeserializeObject<Json>(json);
                

                return jsonFile;
            }
        } //wyciagniecie pliku JSON

        internal static void WriteRaport(Json jsonFile)
        {
            /*Ile osob zaliczylo prace domowa*/
            Regex homeWorkThresholdPerStudentToCut = new Regex(@"-zaliczone");
            int passedHomeworkCounter = 0;
            foreach (var passedHomework in jsonFile.HomeworkList)
            {
                var homeWorkThresholdMatchToCut = homeWorkThresholdPerStudentToCut.IsMatch(passedHomework);
                if (homeWorkThresholdMatchToCut)
                {
                    passedHomeworkCounter++;
                }
            }


            /*Ile osob zaliczylo prace domowa*/
            Regex findHowManyPresencePassed = new Regex(@"-zaliczone");
            int passedPresneceCounter = 0;

            foreach (var passedPresence in jsonFile.PresenceList)
            {

                var PresenceMatchToCut = findHowManyPresencePassed.IsMatch(passedPresence);
                if (PresenceMatchToCut)
                {
                    passedPresneceCounter++;
                }
            }

            Console.WriteLine("Nazwa kursu: "+ jsonFile.CourseName);
            Console.WriteLine("Prowadzacy: " + jsonFile.TeacherName);
            Console.WriteLine("Sredni procent z prac domowych: " + AverageParcentage(jsonFile.HomeworkList));
            Console.WriteLine("Średni procent z obecnosci: " + AverageParcentage(jsonFile.PresenceList));
            Console.WriteLine("Sredni procent z prac domowych: " + AverageParcentage(jsonFile.HomeworkList) + "%");
            Console.WriteLine("Średni procent z obecnosci: " + AverageParcentage(jsonFile.PresenceList) + "%");
            Console.WriteLine("Ilosc osób z zaliczona praca domowa: " + passedHomeworkCounter);
            Console.WriteLine("Ilosc osób z zaliczona obecnosc: " + passedPresneceCounter);
            Console.ReadLine();
            
        } // wypisanie raportu

        internal static int AverageParcentage(Array jsonFile)
        {
            int countOfOccurrence = 0;
            var sum = 0;
            

            foreach (var student in jsonFile)
            {
                var studentString= student.ToString();
                var parcentToCut = Regex.Match(studentString, @"\(([^)]*)\)").Groups[1].Value;
                var parcent = parcentToCut.Remove(parcentToCut.Length - 1);
                countOfOccurrence++;
                sum += Int32.Parse(parcent); ;
                
            }
            var avarege = CalculateAverage(sum, countOfOccurrence);
            return avarege;
        }//zwraca srednia tablic

        internal static int CalculateAverage(int sum, int counterOfOccurence)
        {

            return sum/counterOfOccurence;
        } //wyliczenie średniej na podstawie sumy, oraz ilosci wystapien
    }
}