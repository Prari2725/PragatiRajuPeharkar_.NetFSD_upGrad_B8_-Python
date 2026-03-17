

//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class Student
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//public class Program
//{
//    public static void Main()
//    {
//        List<Student> students = new List<Student> {
//            new Student { Name = "Amit", Age = 17 },
//            new Student { Name = "Priya", Age = 19 },
//            new Student { Name = "Raj", Age = 20 },
//            new Student { Name = "Neha", Age = 18 }
//        };

//        // Query Syntax
//        var adultStudentsQuery = from student in students
//                                 where student.Age >= 18
//                                 select student;

//        Console.WriteLine("Adult Students (Query Syntax):");
//        foreach (var student in adultStudentsQuery)
//        {
//            Console.WriteLine(student.Name);
//        }

//        // Method Syntax
//        var adultStudentsMethod = students.Where(student => student.Age >= 18);

//        Console.WriteLine("\nAdult Students (Method Syntax):");
//        foreach (var student in adultStudentsMethod)
//        {
//            Console.WriteLine(student.Name);
//        }
//    }
//}



//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Student
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public string Course { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        // Sample data: List of students
//        List<Student> students = new List<Student>
//        {
//            new Student { Id = 1, Name = "Amit", Age = 20, Course = "Mathematics" },
//            new Student { Id = 2, Name = "Riya", Age = 22, Course = "Physics" },
//            new Student { Id = 3, Name = "Raj", Age = 21, Course = "Mathematics" },
//            new Student { Id = 4, Name = "Neha", Age = 19, Course = "Biology" },
//            new Student { Id = 5, Name = "Sita", Age = 23, Course = "Physics" }
//        };

//        // Filtering students who are older than 20 and enrolled in Mathematics
//        var filteredStudents = students.Where(s => s.Age > 20 && s.Course == "Mathematics");

//        Console.WriteLine("Students older than 20 and enrolled in Mathematics:");
//        foreach (var student in filteredStudents)
//        {
//            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Course { get; set; }
}

class Program
{
    static void Main()
    {
        // Sample data: List of students
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Amit", Age = 20, Course = "Mathematics" },
            new Student { Id = 2, Name = "Riya", Age = 22, Course = "Physics" },
            new Student { Id = 3, Name = "Raj", Age = 21, Course = "Mathematics" },
            new Student { Id = 4, Name = "Neha", Age = 19, Course = "Biology" },
            new Student { Id = 5, Name = "Sita", Age = 23, Course = "Physics" }
        };

        // Grouping students by Course
        var groupedStudents = students.GroupBy(s => s.Course);

        // Displaying grouped results
        foreach (var group in groupedStudents)
        {
            Console.WriteLine($"Course: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"  Name: {student.Name}, Age: {student.Age}");
            }
        }
    }
}
