using System;

namespace Register.Cli
{
    public class ProgramLoop
    {
        public enum CommandTypes { AddNewCourse, AddNewStudent, AddNewDay, AddNewHomework, Exit }

        public void Execute()
        {
            var exit = false;

            while (!exit)
            {
                var choose =

                switch (choose)
                {

                    //case "adddayofcourse":
                    //AddDayOfCourse();
                    //break;
                    case "addnewday":
                        AddNewDay();
                        break;

                    case "addhomework":
                        AddNewHomework();
                        break;

                    case "print":
                        Print();
                        break;

                    case "exit":
                        exit = false;
                        break;


                    default:
                        Console.WriteLine("Wybrana opcja, nie istnieje.\n\n");
                        break;
                        return;
                }
            }

       
        
    
    }
}