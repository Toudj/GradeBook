using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book 
    {
        public Book(string name)
        {
           _grades = new List<double>(); 
           _name = name;
        }
        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
           var result = new Statistics();
           result.Total = 0.0;
           result.nStudents = 0;
           result.High = double.MinValue;
           result.Low = double.MaxValue;
           foreach(var grade in _grades)
           {
               result.High = Math.Max(grade, result.High);
               result.Low = Math.Min(grade, result.Low);
               result.Total  += grade;

           }
            result.nStudents = _grades.Count;
            result.Average = result.Total/result.nStudents;
            return result;

        }

        public void show()
        {
            /*
            Console.WriteLine($"Total of Grades : {sum} ");
            Console.WriteLine($"Number of students : {_grades.Count} ");
            Console.WriteLine($"Average grade : {sum/_grades.Count:N1} ");
            Console.WriteLine($"The Lowest grade : {lowGrade:N1}");
            Console.WriteLine($"The highest grade : {highGrade:N1}");
            */
        }

        private List<double> _grades;
        private string _name;

    }
}