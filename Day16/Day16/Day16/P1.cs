public class p1
{
    public static void value()
    {
        int a, b, c;
        double n;
        string m;
        char p;
        Console.WriteLine("enter first no");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter second no");
        b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter float no");
        n = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("enter char");
        p = Convert.ToChar(Console.ReadLine());


        c = a + b;
        Console.WriteLine("the result is " + c + " " + n + "" + p);
    }
}
