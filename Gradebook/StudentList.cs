using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class StudentList : List<Student>
    {
        public void Fill()
        {
            List<Student> students = StudentDB.GetStudents();
            foreach (Student student in students)
                base.Add(student);
        }

        public void Save()
        {
            StudentDB.SaveStudents(this);
        }
    }
}
