//using System.IO;


//class Program


//{

//    public void WriteData()
//    {
//        StreamWriter sw = new StreamWriter("D:\\uGE_Dotnet FSD with Python\\Daywise content\\Day22\\fileip.txt");
//        Console.WriteLine("Enter the text  to write in the file:");
//        string str = Console.ReadLine();

//        sw.WriteLine(str);
//        sw.Flush();
//        sw.Close();
//    }
//}



//class Program1
//{
//    public void ReadData()
//    {
//        StreamReader sw = new StreamReader("D:\\uGE_Dotnet FSD with Python\\Daywise content\\Day22\\fileip.txt");
//        Console.WriteLine("content of the file");
//        sw.BaseStream.Seek(0, SeekOrigin.Begin);
//        string s = sw.ReadLine();
//        while (s != null)
//        {
//            Console.WriteLine(s);
//            s = sw.ReadLine();

//        }
//        sw.Close();

//    }
//}


//public class fileApp
//{
//    public static void Main()
//    {
//        Program p = new Program();
//        p.WriteData();

//        Program1 p1 = new Program1();
//        p1.ReadData();

//        Console.WriteLine("Press Enter to exit...");
//        Console.ReadLine();


//    }

//}

using System;
using System.IO;

class Program
{
    public void WriteData()
    {
        Console.WriteLine("Enter the text to write in the file:");
        string str = Console.ReadLine();

        try
        {
            FileStream fs = new FileStream(
                "D:\\uGE_Dotnet FSD with Python\\Daywise content\\Day22\\fileip.txt",
                FileMode.Append,
                FileAccess.Write
            );

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(str);

            sw.Close(); 

            Console.WriteLine("Message written successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class Program1
{
    public void ReadData()
    {
        try
        {
            FileStream fs = new FileStream(
                "D:\\uGE_Dotnet FSD with Python\\Daywise content\\Day22\\fileip.txt",
                FileMode.OpenOrCreate,
                FileAccess.Read
            );

            StreamReader sr = new StreamReader(fs);

            Console.WriteLine("Content of the file:");

            string s = sr.ReadLine();
            while (s != null)
            {
                Console.WriteLine(s);
                s = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

public class fileApp
{
    public static void Main()
    {
        Program p = new Program();
        p.WriteData();

        Program1 p1 = new Program1();
        p1.ReadData();

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}



