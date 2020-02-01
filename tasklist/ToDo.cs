using System;
using System.Text;
using System.Collections.Generic;

namespace tasklist
{
    public class ToDo
    {
        public string Name {get;set;}
        public DateTime Due {get;set;}
        public string Description {get;set;}
        public bool Complete {get;set;}

        public ToDo(){}
        public ToDo(string name, DateTime due, string description)
        {
            Name = name;
            Due = due;
            Description = description;
        }

        public void MarkComplete()
        {
            Complete = true;
        }

        public static void AddToDo(List<ToDo> listOfTasks)
        {
            ToDo newToDo = new ToDo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            newToDo.Name = Methods.GetUserInput("Who will be responsible for this task?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            newToDo.Due = DateTime.Parse(Methods.GetUserInput("When does this task need to be completed by?"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            newToDo.Description = Methods.GetUserInput("Give a brief discription of the task:");

            listOfTasks.Add(newToDo);
        }

        public static void DeleteFromList(List<ToDo> listOfTasks)
        {
            DisplayList(listOfTasks);
            Console.ForegroundColor = ConsoleColor.Yellow;
            int input = Methods.CheckRange(int.Parse(Methods.GetUserInput("Which task would you like to delete?")), 1, listOfTasks.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            bool confirm = Methods.ValidateInput("Are you sure you wish to delete this task?");
            if(confirm)
            {
                listOfTasks.RemoveAt(input - 1);
            }
            else
            {
                
            }
        }

        public static void DisplayList(List<ToDo> listOfTasks)
        {
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Complete    Due     Name    Description");
            Console.ResetColor();
            foreach(ToDo t in listOfTasks)
            {
                Console.WriteLine($"{i++}.  {t.Complete} - {t.Due.ToShortDateString()} - {t.Name} - {t.Description}");
            }
        }

        public static void FilterList(List<ToDo> listOfTasks)
        {
            int i = 1;
            int option = Methods.CheckRange(int.Parse(Methods.GetUserInput("Filter List options\n1. Name\n2. Due Date\n3. Exit")), 1, 3);
            switch(option)
            {
                case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                string name = Methods.GetUserInput("Which persons task would you like to see?");
                foreach(ToDo t in listOfTasks)
                {
                    if(t.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine($"{i++}.  {t.Complete} - {t.Due.ToShortDateString()} - {t.Name} - {t.Description}");
                    }
                    else{}
                }
                break;

                case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                DateTime dueDate = DateTime.Parse(Methods.GetUserInput("See tasks due before what date?"));
                foreach(ToDo t in listOfTasks)
                {
                    if(t.Due <= dueDate)
                    {
                        Console.WriteLine($"{i++}.  {t.Complete} - {t.Due.ToShortDateString()} - {t.Name} - {t.Description}");
                    }
                    else{}
                }
                break;

                case 3:
                break;
            }

        }

        public static void EditTask(List<ToDo> listOfTasks)
        {
           DisplayList(listOfTasks);
           Console.ForegroundColor = ConsoleColor.Yellow;
           int taskNumber = Methods.CheckRange(int.Parse(Methods.GetUserInput("Which task do you want to edit?")), 1, listOfTasks.Count);
           int propNumber = Methods.CheckRange(int.Parse(Methods.GetUserInput("Will you change the...\n1. Name\n2. Due Date\n3. Description")), 1, 3);
           if(propNumber == 1)
           {
               Console.ForegroundColor = ConsoleColor.Yellow;
               listOfTasks[taskNumber - 1].Name = Methods.GetUserInput("Who will be responsible for this task now?");
           }
           if(propNumber == 2)
           {
               Console.ForegroundColor = ConsoleColor.Yellow;
               listOfTasks[taskNumber - 1].Due = DateTime.Parse(Methods.GetUserInput("What is the new due date? (mm/dd/yyyy)"));
           }
           if(propNumber == 3)
           {
               Console.ForegroundColor = ConsoleColor.Yellow;
               listOfTasks[taskNumber - 1].Description = Methods.GetUserInput("Input the new task description:");
           }
        }

    }
}