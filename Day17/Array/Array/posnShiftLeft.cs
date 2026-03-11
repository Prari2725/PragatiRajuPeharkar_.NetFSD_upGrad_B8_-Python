//shift posn of aary by 1 on left side
public class posnShiftLeft
{

    public void shiftLeft()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int temp = arr[0];

        Console.WriteLine("Original array:");
        for (int i = 0; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }



        arr[arr.Length - 1] = temp; 
        Console.WriteLine("Array after left shift:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}



