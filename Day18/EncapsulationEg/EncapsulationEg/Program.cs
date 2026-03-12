using System;

class BankAccount
{
    private double bal;

    public BankAccount(double initialBalance)
    {
        bal = initialBalance;
    }

    public void Deposit(double amt)
    {
        bal += amt;
        Console.WriteLine("Deposit successful: " + amt);
    }

    public void Withdraw(double amt)
    {
        if (amt > bal)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            bal -= amt;
            Console.WriteLine("Withdraw successful: " + amt);
        }
    }

    public double GetBalance()
    {
        return bal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount(2000);

        int choice;
        double amount;

        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Check Balance");

        Console.Write("Enter your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter amount to deposit: ");
                amount = Convert.ToDouble(Console.ReadLine());
                acc.Deposit(amount);
                break;

            case 2:
                Console.Write("Enter amount to withdraw: ");
                amount = Convert.ToDouble(Console.ReadLine());
                acc.Withdraw(amount);
                break;

            case 3:
                Console.WriteLine("Current Balance = " + acc.GetBalance());
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }

        Console.WriteLine("Final Balance = " + acc.GetBalance());
    }
}