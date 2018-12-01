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

        public string Description
        {
            get
            {
                if(LetterGrade is null)
                {
                    return null;
                }
                string description;
                switch (LetterGrade)
                {
                    case "A":
                        description = "Excellent";
                        break;
                    case "B":
                        description = "Good";
                        break;
                    case "C":
                        description = "Average";
                        break;
                    case "D":
                        description = "Below Average";
                        break;
                    default:
                        description = "Failed";
                        break;
                }
                return description;
            }
        }
    }
}