using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook gradeBook = new GradeBook("The Graduator");

            while (true)
            {
                Console.Write("Enter a grade between 0 and 100 or write 'quit' to exit: ");
                string answer = Console.ReadLine();
                if(answer.Equals("quit"))
                {
                    break;
                }
                else
                {
                    float gradeValue = float.Parse(answer);
                    if(gradeValue < GradeBook.MIN_GRADE || gradeValue > GradeBook.MAX_GRADE)
                    {
                        Console.WriteLine("Grade value outside grade interval");
                    }
                    else
                    {
                        gradeBook.AddGrade(gradeValue);
                    }
                }
            }

            GradeStatistics stats = gradeBook.ComputeGrades();

            Console.WriteLine("Max grade is {0}", stats.MaxGrade);
            Console.WriteLine("Min grade is {0}", stats.MinGrade);
            Console.WriteLine("Average grade is {0}", stats.AverageGrade);
            Console.WriteLine("Letter grade is {0}", stats.LetterGrade);
            Console.WriteLine("Grade description: {0}", stats.Description);
        }
    }
}
