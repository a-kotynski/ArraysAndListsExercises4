using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.udemy.com/course/csharp-tutorial-for-beginners/learn/lecture/2910726#content
/* 4 - Write a program that asks the user to continuously enter a number
 * or type "Quit" to exit. 
 * The list of numbers may include duplicates. 
 * Display the unique numbers that the user has entered.*/

// almost all taken from https://github.com/chrisvasqm/csharp-beginners/blob/master/CSharp%20for%20Beginners%20Exercises/Arrays%20and%20Lists/DisplayUniqueNumbers.cs
namespace ArraysAndListsExercises4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number or \"Quit\" to exit: ");
            var numberList = new List<int>();

            while (true)
            {
                var enteredInput = Console.ReadLine();

                if (enteredInput != null && enteredInput.ToLower() == "quit") //ToLower() changes string to small case characters
                {
                    var uniqueNumbers = GetUniqueNumbersList(numberList);
                    uniqueNumbers.Sort();
                    uniqueNumbers.ForEach(Console.WriteLine);
                }
                else
                {
                    numberList.Add(Convert.ToInt32(enteredInput));
                }
            }
        }
        private static List<int> GetUniqueNumbersList(IEnumerable<int> numbers)
        {
            //wtf how was I supposed to know that
            return numbers
                .GroupBy(number => number)
                .Where(number => number
                .Count() == 1)
                .SelectMany(number => number)
                .ToList();
        }
    }
}