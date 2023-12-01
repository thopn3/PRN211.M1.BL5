using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Topic2_OOP
{
    internal class CourseDAO
    {
        List<Course> courses;
        Regex regex;
        public CourseDAO() 
        { 
            courses = new List<Course>();
        }
        public void InputCourse()
        {
            // Khởi tạo 1 course mới (null)
            Course course = new Course();


            // Input Course Code:
            Console.WriteLine("Course: #"+courses.Count+1);
            Console.Write("Enter Course Code: ");
            while (true)
            {
                course.CourseCode = Console.ReadLine();
                regex = new Regex(@"^([A-Z]{3})\d{3}$");
                if(!regex.IsMatch(course.CourseCode)) 
                {
                    Console.Write("Invalid Course Code!\nTry again: ");
                }
                else
                {
                    // Kiểm tra sự tồn tại của CourseCode trong courses
                    if (courses.Where(c => c.CourseCode == course.CourseCode).Count() > 0)
                        Console.Write("This Course Code exited!\nTry again: ");
                    else
                        break;
                }
            }

            // Input Course Name:
            Console.Write("Enter Course Name: ");
            course.CourseName = Console.ReadLine();

            // Input list Students for this course
            int numberOfStudents;
            Console.Write("Enter number of Students in this Course: ");
            while(!int.TryParse(Console.ReadLine(), out numberOfStudents) || numberOfStudents < 0)
            {
                Console.Write("Invalid integer number number!\nTry again: ");
            }

            for (int i = 0; i < numberOfStudents; i++)
            {
                // Khai báo 1 đối tượng để kiểm tra dữ liệu có khớp với mẫu theo yêu cầu
                Regex reg;
                string roll, name, gender;
                int age;
                DateTime dob;
                Console.WriteLine("Student: #"+(i+1));

                Console.Write("Enter RollNumber: ");
                while (true)
                {
                    string pattern = @"^(HE|SE|HS|BA)\d{6}$";
                    roll = Console.ReadLine();
                    reg = new Regex(pattern);
                    if (!reg.IsMatch(roll))
                    {
                        Console.Write("Invalid RollNumber!\nRe-Enter RollNumber: ");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Enter Fullname: ");
                while (true)
                {
                    string pattern = @"^([A-Za-z\s]+)$";
                    name = Console.ReadLine();
                    reg = new Regex(pattern);
                    if (!reg.IsMatch(name))
                        Console.Write("Name must be alphabet characters!\nRe-Enter Name: ");
                    else
                        break;
                }

                Console.Write("Enter Age: ");
                while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
                {
                    Console.Write("Invalid number!\nRe-Enter Age: ");
                }

                Console.Write("Enter Gender: ");
                while (true)
                {
                    gender = Console.ReadLine();
                    if (gender.Equals("Male") || gender.Equals("Female"))
                        break;
                    else
                        Console.Write("Invalid Gender!\nRe-Enter Gender: ");
                }

                Console.Write("Enter DOB: ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    Console.Write("Invalid format DOB!\nRe-Enter DOB (dd/MM/yyyy): ");
                }

                // Khai báo đối tượng kiểu Student và gán giá trị cho các thuộc tính
                Student student = new Student(roll, name, age, gender, dob);

                // Nhập điểm số của sinh viên trong môn học này
                double gpa;
                Console.Write("Enter GPA: ");
                while (!double.TryParse(Console.ReadLine(),out gpa) || gpa <0 || gpa > 10)
                {
                    Console.Write("Invalid GPA ([0 - 10])!\nTry again: ");
                }

                // Thêm thông tin của sinh viên và điểm số vào Course
                course.studentList.Add(student, gpa);
            }
            courses.Add(course);
        }
        public void RemoveCourse()
        {

        }
        public void PrintCourses()
        {
            Console.WriteLine("--- Information of Courses ---");
            if (courses.Count > 0)
            {
                foreach (var item in courses)
                {
                    Console.WriteLine("Course code: " + item.CourseCode);
                    Console.WriteLine("Course name: " + item.CourseName);
                    Console.WriteLine("Students list: ");
                    Console.WriteLine("RollNumber\tFullName\t\tAge\tGender\tDOB\tGPA");
                    foreach (var s in item.studentList)
                    {
                        Console.WriteLine($"{s.Key.RollNumber}\t{s.Key.Name}\t\t{s.Key.Age}\t{s.Key.Gender}\t{s.Key.Dob}\t{s.Value}");
                    }
                }
                Console.WriteLine("---------------------------");
            }
            else
                Console.WriteLine("Courses is empty");

        }
    }
}
