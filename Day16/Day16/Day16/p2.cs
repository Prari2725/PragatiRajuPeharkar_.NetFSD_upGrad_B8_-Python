class p2
{
    public static void calculator()
    {
        int a, b, c, d, e, f;

        Console.WriteLine("enter first no");
        a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("enter second no");
        b = Convert.ToInt32(Console.ReadLine());

        c = a + b;
        d = a - b;
        e = a * b;
        f = a / b;

        Console.WriteLine("Addition is " + c);
        Console.WriteLine("Subtraction is " + d);
        Console.WriteLine("Multiplication is " + e);
        Console.WriteLine("Division is " + f);


    }
}