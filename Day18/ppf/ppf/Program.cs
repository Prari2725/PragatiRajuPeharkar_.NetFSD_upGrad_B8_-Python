
public interface SBI
{
    void PPF(double amount, int years);
}

public interface HDFC
{
    void PPF(double amount, int years);
}

public interface PNB
{
    void PPF(double amount, int years);
}

public class BankPPF : SBI, HDFC, PNB
{
    void SBI.PPF(double amount, int years)
    {
        double finalAmount = ((amount * 12 * years) / 100) + amount;
        Console.WriteLine("SBI PPF final amount after " + years + " years = " + finalAmount);
    }

    void HDFC.PPF(double amount, int years)
    {
        double finalAmount = ((amount * 9 * years) / 100) + amount;
        Console.WriteLine("HDFC PPF final amount after " + years + " years = " + finalAmount);
    }

    void PNB.PPF(double amount, int years)
    {
        double finalAmount = ((amount * 10 * years) / 100) + amount;
        Console.WriteLine("PNB PPF final amount after " + years + " years = " + finalAmount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        BankPPF b = new BankPPF();

        ((SBI)b).PPF(amount, years);
        ((HDFC)b).PPF(amount, years);
        ((PNB)b).PPF(amount, years);
    }
}