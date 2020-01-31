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

        public void EditDescription(string input)
        {
            Description = input;
        }

        public void EditDate(DateTime date)
        {
            Due = date;
        }

        public void EditName(string name)
        {
            Name = name;
        }

        public static void AddToDo(List<ToDo> listOfTasks)
        {
            ToDo newToDo = new ToDo();
            newToDo.Name = Methods.GetUserInput("Who will be responsible for this task?");
            newToDo.Due = DateTime.Parse(Methods.GetUserInput("When does this task need to be completed by?"));
            newToDo.Description = Methods.GetUserInput("Give a brief discription of the task:");

            listOfTasks.Add(newToDo);
        }

        public static void DeleteFromList(List<ToDo> listOfTasks)
        {
            DisplayList(listOfTasks);
            int input = Methods.CheckRange(int.Parse(Methods.GetUserInput("Which task would you like to delete?")), 1, listOfTasks.Count);
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
            foreach(ToDo t in listOfTasks)
            {
                Console.WriteLine($"{i++}.  {t.Complete} - {t.Due.ToShortDateString()} - {t.Name} - {t.Description}");
            }
            // int input = Methods.CheckRange(int.Parse(Methods.GetUserInput("1. Full List\n2. List for Name\n3. List before Due Date")), 1, 3);
            // switch(input)
            // {
            //     case 1:
                
            //     break;

            //     case 2:
            //     break;

            // }
        }

        public static void EditTask(List<ToDo> listOfTasks)
        {
           DisplayList(listOfTasks);
           int taskNumber = Methods.CheckRange(int.Parse(Methods.GetUserInput("Which task do you want to edit?")), 1, listOfTasks.Count);
           int propNumber = Methods.CheckRange(int.Parse(Methods.GetUserInput("Will you change the...\n1. Name\n2. Due Date\n3. Description")), 1, 3);
           
        }

    }
}