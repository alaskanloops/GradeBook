using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                name = value;
            }
        }

        public event NameChangedDelegate NameChanged;
    }
}
