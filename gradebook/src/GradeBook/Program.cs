using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           var grades = new[]{12.7, 20.5, 30.5};
           var sum = 0.0;
            
           foreach(var i in grades)
           {
               sum += i;

           }
            Console.WriteLine($"Sum : {sum} ");


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
