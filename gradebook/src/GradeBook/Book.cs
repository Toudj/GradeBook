using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NameObject
    {
        public NameObject(string name)
        {
            _name = name;
        }

        public string _name
        {
            get;
            set;
        }
    }
    public interface Ibook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string _name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NameObject, Ibook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{_name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

        }
        public override Statistics GetStatistics()
        {


            var result = new Statistics();
            using(var reader = File.OpenText($"{_name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            _grades = new List<double>();
        }
        public void AddGrade(char letter)
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
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            if (_grades.Count != 0)
            {
                var result = new Statistics();

                foreach (var grade in _grades)
                {
                    result.Add(grade);
                }
                return result;
            }
            else
            {
                Console.WriteLine("There is zero value to compute");
                return new Statistics();
            }

        }
        private List<double> _grades;


    }
}