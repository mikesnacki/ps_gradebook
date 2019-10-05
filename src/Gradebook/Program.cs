using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new BookDisk("Mike's book");
            book.GradeAdded+=OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("Grade was added");
            } 

            Console.WriteLine($"The lowest is {stats.Low:N1}, \nthe average is {stats.Average:N1}, \nthe highest is {stats.High:N1}\nThe letter is {stats.Letter}");
        }

        static void EnterGrade(IBook book)
        {
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
        }
    }
}
