using System.Collections;
using System.IO;

namespace Grades
{
    public interface IGradeTracker : IEnumerable
    {
        void AddGrade(float gradeValue);
        GradeStatistics ComputeGrades();
        void WriteGrades(TextWriter textWriter);
    }
}