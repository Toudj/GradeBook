using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Ibook book = new DiskBook("Science");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();


            Console.WriteLine($"Book Name: {book._name}");
            Console.WriteLine($"Total of Grades : {stats.Total} ");
            Console.WriteLine($"Number of academics : {stats.nAcademics} ");
            Console.WriteLine($"Average grade : {stats.Average:N1} ");
            Console.WriteLine($"The Lowest grade : {stats.Low:N1}");
            Console.WriteLine($"The highest grade : {stats.High:N1}");
            Console.WriteLine($"The Letter grade : {stats.Letter}");
        }

        private static void EnterGrades(Ibook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or q to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

        }

        static void OnGradeAdded(object sender, EventArgs e){
            Console.WriteLine("A grade was added");

        }
    }
  
}
