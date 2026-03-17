
class Product
{
    private double price;
    public string Name {  get; set; }
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative");
            }
            else
            {
                price = value;
            }
        }
    }

    // virtual method
    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05);
    }
}

class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15);
    }
}

class Program
{
    static void Main()
    {
        Product p;

        // Electronics
        p = new Electronics();
        p.Name = "Laptop";
        p.Price = 20000;

        Console.WriteLine("Electronics Final Price after 5% discount = " + p.CalculateDiscount());

        // Clothing
        p = new Clothing();
        p.Name = "T-Shirt";
        p.Price = 2000;

        Console.WriteLine("Clothing Final Price after 15% discount = " + p.CalculateDiscount());
    }
}