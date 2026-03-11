//count the frequency of each element in an array.

public class frequency
{
    public void calculatefreq()
    {
        int[] arr = { 1, 2, 3, 4, 5, 1, 2, 3 };
        for (int i = 0; i < arr.Length; i++)
        {
            int count = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                    arr[j] = -1; 
                }
            }
            if (arr[i] != -1)
            {
                Console.WriteLine($"Element: {arr[i]}, Frequency: {count}");
            }
        }


    }

}




