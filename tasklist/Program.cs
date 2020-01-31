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
            ToDo t1 = new ToDo("Ryan", DateTime.Parse("2/3/2020"), "Complete Task List Capstone");
            ToDo t2 = new ToDo("Stephen", DateTime.Parse("2/6/2020"), "Grade Student Capstones");
            ToDo t3 = new ToDo("Erik", DateTime.Parse("2/28/2020"), "Convert Task List to web/mobile app");

            List<ToDo> tasks = new List<ToDo>{t1, t2, t3};

            while(proceed)
            {
                Console.WriteLine("MENU\n1. List Tasks\n2. Add Task\n3. Edit Task\n4. Delete Task\n5. Mark Task Complete\n6. Quit");
                int menu1 = Methods.CheckRange(int.Parse(Methods.GetUserInput("Choose an item form the menu")), 1, 6);

                switch(menu1)
                {
                    case 1:
                    ToDo.DisplayList(tasks);
                    break;

                    case 2:
                    ToDo.AddToDo(tasks);
                    break;

                    case 3:
                    break;

                    case 4:
                    ToDo.DeleteFromList(tasks);
                    break;

                    case 5:
                    ToDo.DisplayList(tasks);
                    int input = Methods.CheckRange(int.Parse(Methods.GetUserInput("Which task has been completed")), 1, tasks.Count);
                    tasks[input - 1].MarkComplete();
                    break;

                    case 6:
                    Environment.Exit(0);
                    break;
                }
                proceed = Methods.ValidateInput("Would you like to continue in the task list?");
            }
        }
    }
}
