using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Mike's book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.AddGrade(56.1);
            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest is {stats.Low}, the average is {stats.Average} the highest is {stats.High}");
        }
    }

    
}
