using System;
using System.Text;
using System.Collections.Generic;

namespace tasklist
{
    class Program
    {
        static void Main(string[] args)
        {
            bool proceed = true;
            ToDo t1 = new ToDo("Ryan", DateTime.Parse("2/2/2020"), "Complete Task List Capstone");
            ToDo t2 = new ToDo("Stephen", DateTime.Parse("2/6/2020"), "Grade Student Capstones");
            ToDo t3 = new ToDo("Erik", DateTime.Parse("2/28/2020"), "Convert Task List to web/mobile app");
            ToDo t4 = new ToDo("Ryan", DateTime.Parse("2/3/2020"), "Turn in completed task list");

            List<ToDo> tasks = new List<ToDo>{t1, t2, t3, t4};

            while(proceed)
            {
                Console.WriteLine("MENU\n1. List Tasks\n2. Add Task\n3. Edit Task\n4. Delete Task\n5. Mark Task Complete\n6. Quit");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int menu1 = Methods.CheckRange(Methods.GetUserInput("Choose an item from the menu"), 1, 6);

                switch(menu1)
                {
                    case 1:
                    ToDo.DisplayList(tasks);
                    ToDo.FilterList(tasks);
                    break;

                    case 2:
                    ToDo.AddToDo(tasks);
                    break;

                    case 3:
                    ToDo.EditTask(tasks);
                    break;

                    case 4:
                    ToDo.DeleteFromList(tasks);
                    break;

                    case 5:
                    ToDo.DisplayList(tasks);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int input = Methods.CheckRange(Methods.GetUserInput("Which task has been completed"), 1, tasks.Count);
                    tasks[input - 1].MarkComplete();
                    break;

                    case 6:
                    Environment.Exit(0);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                proceed = Methods.ValidateInput("Would you like to continue in the task list?");
            }
        }
    }
}
