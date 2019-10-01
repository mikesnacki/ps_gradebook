using System;
using System.Collections.Generic;
using System.Text;

namespace gradebook
{
    class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            double result = 0.0;
            double average;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;

            foreach (double grade in grades)
            {
                result += grade;
                highGrade = Math.Max(grade, highGrade);
                lowGrade = Math.Min(grade, lowGrade);
            }
            average = result / grades.Count;

            Console.WriteLine($"The lowest is {lowGrade}, the average is {average} the highest is {highGrade}");
        }

    }
}
