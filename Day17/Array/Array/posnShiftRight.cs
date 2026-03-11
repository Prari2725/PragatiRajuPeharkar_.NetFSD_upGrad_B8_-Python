
public class posnShiftRight
{

    public void shiftRight()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int temp = arr[arr.Length - 1];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[0] = temp; 
        Console.WriteLine("Array after right shift:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}
