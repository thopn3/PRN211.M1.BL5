using System.Globalization;

// 1. Hoạt động nhập nhập xuất (Input/Output) cơ bản trong C#
//Console.WriteLine("Hello World!");

int x;
//Console.Write("Enter x: ");
//x = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("x = " + x);

// ----------------------------------------------------
// 2. var và dynamic keyword
//var m = 3.5;
////m = "Hello"; // Lỗi
//Console.WriteLine("m datatype is: " + m.GetType());

//dynamic n = 10;
//Console.WriteLine("n datatype is: " + n.GetType());

//n = "Hello";
//Console.WriteLine("n datatype is: " + n.GetType());

//n = false;
//Console.WriteLine("n datatype is: " + n.GetType());

// ----------------------------------------------------
// 3. Chuỗi nội suy (String interpolation)
//var name = "Soren";
//var salary = 200.234;
//var result = $"Name:{name,7}, Salary:{salary,8:N2}";
//Console.WriteLine(result);

// 4. Nhập giá trị và kiểm tra tính hợp lệ. Nếu sai định dạng, yêu cầu nhập lại.Và in ra trên 1 dòng.
//string name;
//int age;
//double score;
//DateTime dob;

//Console.Write("Enter name: ");
//name = Console.ReadLine();

//Console.Write("Enter age: ");
//while(!int.TryParse(Console.ReadLine(), out age))
//{
//    Console.Write("Invalid age!\nRe-Enter age: ");
//}

//Console.Write("Enter score: ");
//while (!double.TryParse(Console.ReadLine(), out score))
//{
//    Console.Write("Invalid score!\nRe-Enter score: ");
//}

//Console.Write("Enter Date of birth: ");
//while (!DateTime.TryParseExact(Console.ReadLine(),
//    "dd/MM/yyyy", 
//    CultureInfo.InvariantCulture,
//    DateTimeStyles.None, 
//    out dob))
//{
//    Console.Write("Invalid format DOB!\nRe-Enter DOB (dd/MM/yyyy): ");
//}

//Console.WriteLine($"Name: {name}, Age: {age}, Score: {score}, DOB: {dob:dd/MM/yyyy}");


// 5. Từ khóa ref, out, params trong C#
void SumNumbers(out int result, params int[] numbers)
{
    result = 0;
    foreach (int item in numbers)
    {
        result += item;
    }
}

int total;
SumNumbers(out total, 3, 4, 2, 5);
Console.WriteLine("Total of numbers = " + total);

// Cách gọi truyền thống
int[] list = { 3, 1, 2, 5 };
SumNumbers(out total, list);
Console.WriteLine("Sum numbers = " + total);

// Bài tập:
/**
 * Viết 1 CT "Quản lý thông tin sinh viên". Chương trình cho phép người dùng thực hiện
 * các tính năng sau:
 * 1. Nhập số lượng sinh viên cần quản lý. Sau đó nhập thông tin của các sinh viên gồm:
 *      - Mã: string
 *      - Tên: string
 *      - Tuổi: int
 *      - Giới tính: string
 *      - Ngày sinh: DateTime
 *      - Kết quả học tập (AVG): double
 *    Yêu cầu:
 *      - Kiểm tra tính hợp lệ của dữ liệu:
 *          + Mã: Bắt đầu bởi 2 kí tự hoặc (SE, HE, BA, HS), theo sau là 6 kí tự số
 *          + Tên: Chỉ chứa các kí tự từ A-Z | a-z
 *          + Tuổi: Đúng định dạng số nguyên và >=18
 *          + Giới tính: Chỉ cho nhập giá trị là Male | Female
 *          + Ngày sinh: Theo định dạng dd/MM/yyyy
 *          + Kết quả học tập: Đúng định dạng số thực và nằm trong đoạn [0-10]
 *      - Nếu sai định dạng dữ liệu, yêu cầu người dùng nhập lại
 * 2. In danh sách SV theo định dạng sau:
 *      Ma      Ho va ten       Tuoi        Gioi tinh       Ngay sinh       KQHT
 *      1       Nguyen V Nam    20          Male            20/11/2004      7.5
 *      ..      ...             ...         ...             ...             ...
 * 3. Tìm kiếm và in ra các sinh viên theo tên có chứa chuỗi cần tìm
 * 
 * 4. Sắp xếp và in ra danh sách các sinh viên theo thứ tự tăng dần của tuổi. Nếu
 *    cùng tuổi thì sắp xếp giới tính theo thứ tự giảm dần.
 * 
 * Viết CT có menu cho người dùng lựa chọn các chức năng.
 */

