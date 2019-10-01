using System;
using System.Collections.Generic;

namespace gradebook
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
            book.ShowStatistics();
        }
    }

    
}
