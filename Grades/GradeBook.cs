using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeBook
    {
        public NameChangedDelegate NameChanged;

        private string _name = "No name yet!";
        public static float MAX_GRADE = 100.0f;
        public static float MIN_GRADE = 0.0f;

        private List<float> grades = new List<float>();

        public GradeBook(string name)
        {
            _name = name;
        }

        public GradeStatistics ComputeGrades()
        {
            var stats = new GradeStatistics
            {
                MaxGrade = GetMaxGrade(),
                MinGrade = GetMinGrade(),
                AverageGrade = GetAverage()
            };
            return stats;
        }

        public string Name { 

            get {
                return _name;
            }
           
           set { 

                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                if (_name != value)
                {

                    var args = new NameChangedEventArgs
                    {
                        ExistingName = _name,
                        NewName = value
                    };

                    NameChanged(this, args);
                }

                _name = value;

            } 
        }

        private float? GetMaxGrade()
        {
            if(grades.Count > 0)
                return grades.Max<float>();
            return null;
        }

        private float? GetMinGrade()
        {
            if (grades.Count > 0)
                return grades.Min<float>();
            return null;
        }

        private float? GetAverage()
        {
            if (grades.Count > 0)
                return grades.Average();
            return null;
        }

        public void AddGrade(float gradeValue)
        {
            grades.Add(gradeValue);
        }

        public void WriteGrades(TextWriter textWriter)
        {
            foreach (var item in grades)
            {
                textWriter.WriteLine(item);
            }
        }
    }
}
