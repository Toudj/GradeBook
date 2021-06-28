using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           var sum = 0.0;
           var notes = new List<double>(){12.7, 20.5, 30.5}; 
           notes.Add(12.0);
           foreach(var i in notes)
           {
               sum += i;

           }
            Console.WriteLine($"Total of Grades : {sum} ");
            Console.WriteLine($"Number of students : {notes.Count} ");
            Console.WriteLine($"Average grade : {sum/notes.Count:N1} ");
            if(args.Length > 0)
            {
                Console.WriteLine("Hello " + args[0] + " !");
                Console.WriteLine($"Hello {args[0]} !");

            }
            else
            {
                Console.WriteLine("Hello");
            }
            
           
        }
    }
  
}
