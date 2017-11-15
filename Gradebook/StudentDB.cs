using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class StudentDB
    {
        private const string dir = @"C:\C# 2012\Files\";
        private const string path = dir + "StudentScores.txt";

        public static List<Student> GetStudents()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            StreamReader textIn =
                new StreamReader(
                    new FileStream(path, FileMode.OpenOrCreate,
                        FileAccess.Read));

            List<Student> students = new List<Student>();
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                Student student = new Student();
                student.StudentInfo = row;
                students.Add(student);
            }
            textIn.Close();

            return students;
        }

        public static void SaveStudents(List<Student> students)
        {
            StreamWriter textOut =
                new StreamWriter(
                    new FileStream(path, FileMode.Create,
                        FileAccess.Write));

            foreach (Student student in students)
            {
                textOut.WriteLine(student.StudentInfo);
            }
            textOut.Close();
        }
    }
}