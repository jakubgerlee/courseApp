using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Cli.Layer.IoHelper
{
    class ConsoleWriteHelper
    {
       

        public static void PrintOperationSuccessMessage(bool success)
        {
            if (success)
            {
                Console.WriteLine("Operacja powiodła sie!");
            }
            else
            {
                Console.WriteLine("Cos poszlo nie tak..");
            }
        }

        public static void CommandListText()
        {
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
        }
    }
}
