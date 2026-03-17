using System;

struct Student
{
    public int rollNo;
    public string name;
    public string course;
    public int marks;
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[100];
        int count = 0;
        int choice;

        do
        {
            Console.WriteLine("\n1. Add Students");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter number of students: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter Roll Number: ");
                        students[count].rollNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        students[count].name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        students[count].course = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        students[count].marks = Convert.ToInt32(Console.ReadLine());

                        count++;
                    }
                    break;

                case 2:
                    Console.WriteLine("\nStudent Records:");
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("Roll No: " + students[i].rollNo +
                                          " | Name: " + students[i].name +
                                          " | Course: " + students[i].course +
                                          " | Marks: " + students[i].marks);
                    }
                    break;

                case 3:
                    Console.Write("Enter Roll Number to search: ");
                    int search = Convert.ToInt32(Console.ReadLine());
                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].rollNo == search)
                        {
                            Console.WriteLine("\nStudent Found:");
                            Console.WriteLine("Roll No: " + students[i].rollNo +
                                              " | Name: " + students[i].name +
                                              " | Course: " + students[i].course +
                                              " | Marks: " + students[i].marks);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Student record not found.");

                    break;
            }

        } while (choice != 4);
    }
}