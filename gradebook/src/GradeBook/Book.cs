using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book 
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

        public void ShowStatistics()
        {
           var sum = 0.0;
           var highGrade = double.MinValue;
           var lowGrade = double.MaxValue;
           foreach(var i in _grades)
           {
               highGrade = Math.Max(i, highGrade);
               lowGrade = Math.Min(i, lowGrade);
               sum += i;

           }
            Console.WriteLine($"Total of Grades : {sum} ");
            Console.WriteLine($"Number of students : {_grades.Count} ");
            Console.WriteLine($"Average grade : {sum/_grades.Count:N1} ");
            Console.WriteLine($"The Lowest grade : {lowGrade:N1}");
            Console.WriteLine($"The highest grade : {highGrade:N1}");
        }
        private List<double> _grades;
        private string _name;

    }
}