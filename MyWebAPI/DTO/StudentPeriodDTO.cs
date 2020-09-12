using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.DTO
{
    public class StudentPeriodDTO
    {
        string studentID;
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        string birthday;
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        string period;
        public string Period
        {
            get { return period; }
            set { period = value; }
        }

    }
}