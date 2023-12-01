using Topic2_OOP;

CourseDAO courseDAO = new CourseDAO();
int choice=0;

while (true)
{
    Console.WriteLine("--- COURSES MANAGEMENT PROGRAM ---");
    Console.WriteLine("1. Input Course information");
    Console.WriteLine("2. Print Courses");
    Console.WriteLine("3. Search Student in course");
    Console.WriteLine("4. Sort Student in course");
    Console.WriteLine("0. Exit");
    Console.Write("Choice - 1, 2, 3, 4: ");


    
    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            courseDAO.InputCourse();
            break;
        case 2:
            courseDAO.PrintCourses();
            break;
        case 0:
            Console.WriteLine("The End!");
            break;
    }
}