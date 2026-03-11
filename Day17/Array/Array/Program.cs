public class Program
{
    public static void Main(string[] args)
    {

        // count the frequency of each element in an array.
        Console.WriteLine("Frequency of each element in the array:\n");
        frequency freq = new frequency();
        freq.calculatefreq();

        //array shift to left by 1
        Console.WriteLine("Array shifting by 1 on left side:\n");
        posnShiftLeft shift = new posnShiftLeft();
        shift.shiftLeft();

        //array shift to right by 1
        Console.WriteLine("Array shifting by 1 on right side:\n");
        posnShiftRight shiftRight = new posnShiftRight();
        shiftRight.shiftRight();

        //pair sum in an array
        Console.WriteLine("Pair sum in an array:\n");
        pairSum pair = new pairSum();
        pair.sum();




    }
}


