using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeBook
    {
        public static float MAX_GRADE = 100.0f;
        public static float MIN_GRADE = 0.0f;

        private List<float> grades = new List<float>();

        public GradeStatistics ComputeGrades()
        {
            var stats = new GradeStatistics();
            stats.MaxGrade = GetMaxGrade();
            stats.MinGrade = GetMinGrade();
            stats.AverageGrade = GetAverage();
            return stats;
        }

        private float GetMaxGrade()
        {
            return grades.Max<float>();
        }

        private float GetMinGrade()
        {
            return grades.Min<float>();
        }

        private float GetAverage()
        {
            return grades.Average();
        }
    }
}
