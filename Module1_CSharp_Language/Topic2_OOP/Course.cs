using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic2_OOP
{
    internal class Course
    {
        private string courseCode;
        private string courseName;
        public Dictionary<Student, double> studentList;

        public string CourseCode { get => courseCode; set => courseCode = value; }
        public string CourseName { get => courseName; set => courseName = value; }

        public Course() 
        {
            studentList = new Dictionary<Student, double>();
        }
    }
}
