
class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20);
    }
}

class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10);
    }
}

class Program
{
    static void Main(string[] args)
    {
        double baseSalary;

        Console.Write("Enter Base Salary: ");
        baseSalary = Convert.ToDouble(Console.ReadLine());

        Employee emp;

        emp = new Manager();
        emp.BaseSalary = baseSalary;
        Console.WriteLine("Manager Salary = " + emp.CalculateSalary());

        emp = new Developer();
        emp.BaseSalary = baseSalary;
        Console.WriteLine("Developer Salary = " + emp.CalculateSalary());
    }
}