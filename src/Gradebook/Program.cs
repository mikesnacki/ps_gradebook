using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Mike's book");
            bool running = true;

            while(true)
            {
                Console.WriteLine("Enter grades, type 'q' or 'quit to stop\n");
                Console.WriteLine("Enter grade: ");
                string resp = Console.ReadLine();

                if (resp.ToLower() =="q" || resp.ToLower() == "quit")
                {
                    break;
                }

                try
                {
                   book.AddGrade(Convert.ToDouble(resp)); 
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                    
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest is {stats.Low:N1}, \nthe average is {stats.Average:N1}, \nthe highest is {stats.High:N1}\n the letter is {stats.Letter}");
        }
    }

    
}
