namespace Grades
{
    class GradeStatistics
    {
        public float? MaxGrade { get; set; }
        public float? MinGrade { get; set; }
        public float? AverageGrade { get; set; }

        public string LetterGrade
        {
            get
            {
                string letterGrade = null;
                if(AverageGrade >= 90.0f)
                {
                    letterGrade = "A";
                }
                else if(AverageGrade >= 80.0f)
                {
                    letterGrade = "B";
                }
                else if(AverageGrade >= 70.0f)
                {
                    letterGrade = "C";
                }
                else if(AverageGrade >= 60.0f)
                {
                    letterGrade = "D";
                }
                else if(AverageGrade < 60.0f)
                {
                    letterGrade = "F";
                }
                return letterGrade;
            }
        }
    }
}