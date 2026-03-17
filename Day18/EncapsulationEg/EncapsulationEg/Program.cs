using System;

class InsBalException : Exception
{
    public InsBalException(string message) : base(message)
    {
    }
}

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
            throw new InsBalException("Withdrawal failed: Insufficient balance!");
        }

        bal -= amt;
        Console.WriteLine("Withdraw successful: " + amt);
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

        int choice = 0;
        double amount;

        while (choice != 4)
        {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            try
            {
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

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (InsBalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.WriteLine("Final Balance = " + acc.GetBalance());
    }
}