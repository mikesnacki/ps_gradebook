using System;
using System.Collections.Generic;
using System.Text;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(pbject sender, EventArgs args);
    public class Book
    {
        private List<double> grades;
        private string name;

        public string Name
        {
            get;
            set;
        }

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100) 
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, EventArgs());
                }
            }
            else 
            {
                throw new ArgumentException("$Invalid {nameof(grade)}");
                Console.WriteLine("Invalid grade");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.Average += grade;
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
            }

            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;                
                default:
                    result.Letter = 'F';
                    break;      
            }

            return result;
        }
    }
}
