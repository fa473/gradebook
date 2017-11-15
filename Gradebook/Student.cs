using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class Student
    {
        private string studentInfo;

        public Student()
        {
        }

        public Student(string studentInfo)
        {
            this.StudentInfo = studentInfo;
        }

        public string StudentInfo
        {
            get
            {
                return studentInfo;
            }
            set
            {
                studentInfo = value;
            }
        }

        public override string ToString()
        {
            return studentInfo;
        }
    }

}
