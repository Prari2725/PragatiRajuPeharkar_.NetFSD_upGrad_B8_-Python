
internal class pairSum
{

   public void sum()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int target = 6;

        Console.WriteLine("Pairs are:");

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == target)
                {
                    Console.WriteLine(arr[i] + " + " + arr[j]);
                }
            }
        }
    }

}

