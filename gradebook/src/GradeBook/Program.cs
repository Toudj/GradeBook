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
           book.ShowStatistics();                 
        }
    }
  
}
