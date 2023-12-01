using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic2_OOP
{
    internal class Student
    {
        private string rollNumber;
        private string name;
        private int age;
        private string gender;
        private DateTime dob;

        // Thiết lập tính chất bao đóng (hoạt động bảo vệ dữ liệu cho đối tượng)
        public string RollNumber { get => rollNumber; set => rollNumber = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Dob { get => dob; set => dob = value; }

        // Constructor (Hàm khởi tạo): Giúp khởi tạo đối tượng và gán giá trị ban đầu cho đối tượng
        public Student(string rollNumber, string name, int age, string gender, DateTime dob)
        {
            this.rollNumber = rollNumber;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.dob = dob;
        }

        // Constructor giúp khởi tạo đối tượng. Nhưng đối tượng được khởi tạo là NULL
        public Student()
        {
        }

        // Phương thức in thông tin của đối tượng
        public override string? ToString()
        {
            return $"{rollNumber}\t{name}\t\t{age}\t{gender}\t{dob:dd/MM/yyyy}";
        }
    }
}
