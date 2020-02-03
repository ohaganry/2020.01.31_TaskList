using System;
using System.Text;
using System.Collections.Generic;

namespace tasklist
{
    public class Methods
    {
       public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static bool ValidateInput(string message)
        {
            string usertInput = GetUserInput(message).ToLower();
            if(usertInput == "y")
            {
                //Console.WriteLine("\n===================================");
                return true;
            }
            else if(usertInput == "n")
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                return ValidateInput(message);
            }
        } 

        public static int CheckRange(string input, int rangeLower, int rangeUpper)
        {
            int number;
            if(int.TryParse(input, out number))
            {
                if(number >= rangeLower && number <= rangeUpper)
                {
                    return number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    input = GetUserInput($"Invalid Input. Input must be {rangeLower}-{rangeUpper}");
                    return CheckRange(input, rangeLower, rangeUpper);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                input = GetUserInput($"Invalid Input. Input must be {rangeLower}-{rangeUpper}");
                return CheckRange(input, rangeLower, rangeUpper);
            }
        }            
    }
}