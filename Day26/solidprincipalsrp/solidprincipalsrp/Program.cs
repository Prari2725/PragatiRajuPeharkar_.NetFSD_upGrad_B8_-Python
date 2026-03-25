using System;
using System.Collections.Generic;

namespace SrpStudentReport
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double Marks { get; set; }

        public Student(int sId, string sName, double smarks)
        {
            StudentId = sId;
            StudentName = sName;
            Marks = smarks;
        }
    }

    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid student object.");
                return;
            }


            if (student.Marks < 0 || student.Marks > 100)
            {
                Console.WriteLine("Marks must be between 0 and 100.");
                return;
            }

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n===== STUDENT PERFORMANCE REPORT =====");

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No student records available.");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Student ID   : " + student.StudentId);
                Console.WriteLine("Student Name : " + student.StudentName);
                Console.WriteLine("Marks        : " + student.Marks);
                Console.WriteLine("Grade        : " + GetGrade(student.Marks));
                Console.WriteLine("Result       : " + GetResult(student.Marks));
            }
        }

        private string GetGrade(double marks)
        {
            if (marks >= 90) return "A+";
            else if (marks >= 75) return "A";
            else if (marks >= 60) return "B";
            else if (marks >= 50) return "C";
            else return "F";
        }

        private string GetResult(double marks)
        {
            return marks >= 40 ? "Pass" : "Fail";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repository = new StudentRepository();
            ReportGenerator reportGenerator = new ReportGenerator();

            int choice;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Report");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        double marks = Convert.ToDouble(Console.ReadLine());

                        repository.AddStudent(new Student(id, name, marks));
                        break;

                    case 2:
                        reportGenerator.GenerateReport(repository.GetAllStudents());
                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 3);
        }
    }
}
    