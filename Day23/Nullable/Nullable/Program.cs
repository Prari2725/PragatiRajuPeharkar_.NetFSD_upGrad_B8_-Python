class lablee
{
    static void Main()
    {
        int? age = null;

        if (age.HasValue)
        {
            Console.WriteLine($"Age: {age.Value}");

        }
        else
        {
            Console.WriteLine("Age is null.");
        }
    }
}