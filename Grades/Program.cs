using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {

        static void Main(string[] args)
        {
            GradeBook gradeBook = new GradeBook("The graduator")
            {
                NameChanged = new NameChangedDelegate((gb, eventArgs) =>
                {
                    Console.WriteLine("Existing name: {0}", eventArgs.ExistingName);
                    Console.WriteLine("New name: {0}", eventArgs.NewName);
                })
            };

            Console.Write("Give the gradebook a name: ");
            gradeBook.Name = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter a grade between 0 and 100 or write 'quit' to exit: ");
                string answer = Console.ReadLine();
                if (answer.Equals("quit"))
                {
                    break;
                }
                else
                {
                    float gradeValue = float.Parse(answer);
                    if (gradeValue < GradeBook.MIN_GRADE || gradeValue > GradeBook.MAX_GRADE)
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
            WriteInfo(gradeBook, stats);
        }

        private static void WriteInfo(GradeBook gradeBook, GradeStatistics stats)
        {
            Console.WriteLine("Max grade is {0}", stats.MaxGrade);
            Console.WriteLine("Min grade is {0}", stats.MinGrade);
            Console.WriteLine("Average grade is {0}", stats.AverageGrade);
            Console.WriteLine("Letter grade is {0}", stats.LetterGrade);
            Console.WriteLine("Grade description: {0}", stats.Description);

            Console.WriteLine();


            using (StreamWriter writer = File.CreateText("/Users/johnlundgren/grades"))
            {
                gradeBook.WriteGrades(writer);
            }

        }
    }
}
