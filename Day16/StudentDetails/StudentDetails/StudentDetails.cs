using System.Net.Cache;

public class studentDetails
{
    public string Name;
    public int Age;
    public string Address;
    public int Sub1;
    public int Sub2;
    public int Sub3;

    public int Total;
    public double Percentage;

    public void getStudentData()

    {
        Console.WriteLine("Enter Student Name:");
        Name = Console.ReadLine();
        Console.WriteLine("Enter Student Age:");
        Age = Convert.ToInt32(Console.ReadLine());
        if (Age < 18)
        {
            Console.WriteLine("Student is not eligible ");
            return;
        }
        Console.WriteLine("Enter Student Address:");
        Address = Console.ReadLine();

        Console.WriteLine("Enter Marks for Subject 1:");
        Sub1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Marks for Subject 2:");
        Sub2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Marks for Subject 3:");
        Sub3 = Convert.ToInt32(Console.ReadLine());

        calResult();
    }

    public void calResult()
    {
        Total = Sub1 + Sub2 + Sub3;
        Percentage = (Total / 300.0) * 100;
    }

    public void displayStudentData()

    {
        if (Age < 18)
        {
            Console.WriteLine("No student record to display.");
            return;
        }
        
        Console.WriteLine("Student Name: " + Name);
        Console.WriteLine("Student Age: " + Age);
        Console.WriteLine("Student Address: " + Address);
        Console.WriteLine("Marks in Subject 1: " + Sub1);
        Console.WriteLine("Marks in Subject 2: " + Sub2);
        Console.WriteLine("Marks in Subject 3: " + Sub3);
        Console.WriteLine("Total Marks: " + Total);
        Console.WriteLine("Percentage: " + Percentage + "%");
    }
}


