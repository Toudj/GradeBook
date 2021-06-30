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
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            if(_grades.Count != 0)
            {
                var result = new Statistics();
                //result.Total = 0.0;
                //result.nAcademics = 0;
                result.High = double.MinValue;
                result.Low = double.MaxValue;
                foreach(var grade in _grades)
                {
                    result.High = Math.Max(grade, result.High);
                    result.Low = Math.Min(grade, result.Low);
                    result.Total  += grade;

                }
                    result.nAcademics = _grades.Count;
                    result.Average = result.Total/result.nAcademics;

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
            else
            {
                
                Console.WriteLine("There is zero value to compute");
                return new Statistics();
            }

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
        public string _name;

    }
}