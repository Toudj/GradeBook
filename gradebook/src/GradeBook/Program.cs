using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Science"); 
            book.AddGrade(89.1);
            book.AddGrade(100);
            book.AddGrade(50);
            book.AddGrade(2);
            book.AddGrade(18);

            var stats = book.GetStatistics();

            Console.WriteLine($"Total of Grades : {stats.Total} ");
            Console.WriteLine($"Number of students : {stats.nStudents} ");
            Console.WriteLine($"Average grade : {stats.Average:N1} ");
            Console.WriteLine($"The Lowest grade : {stats.Low:N1}");
            Console.WriteLine($"The highest grade : {stats.High:N1}");               
        }
    }
  
}
