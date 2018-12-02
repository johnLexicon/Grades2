using System;
using System.Collections;
using System.IO;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {

        public NameChangedDelegate NameChanged;
        protected string _name;

        public string Name
        {

            get
            {
                return _name;
            }

            set
            {

                if (string.IsNullOrEmpty(value))
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

        public abstract void AddGrade(float gradeValue);
        public abstract GradeStatistics ComputeGrades();
        public abstract void WriteGrades(TextWriter textWriter);
        public abstract IEnumerator GetEnumerator();
    }
}
