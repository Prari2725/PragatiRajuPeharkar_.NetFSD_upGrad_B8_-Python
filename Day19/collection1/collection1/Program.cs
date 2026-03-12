//using System.Collections;

//class Program
//{
//    static void Main(string[] args)
//    {


//        ArrayList arr = new ArrayList();
//        arr.Add(10);
//        arr.Add(200);
//        arr.Add(400);
//        arr.Add(200);
//        arr.Add("Revature");
//        arr.RemoveAt(3);
//        arr.RemoveRange(1, 2);
//        arr.Insert(1, 40);

//        foreach (object i in arr)
//        {
//            Console.WriteLine(i);


//        }

//    }
//    }


//using System.Collections;

//class HashTable
//{
//        static void Main(string[] args)
//{
//    Hashtable ht = new Hashtable();
//    ht.Add("eid", 1001);
//    ht.Add("eid1", 1002);
//    ht.Add("name", "amit");
//    ht.Add("Job", "Developer");
//    ht.Add("Salary", 50000);
//    ht.Add("location", "delhi");
//    foreach (object obj in ht.Keys)
//    {
//        Console.WriteLine(obj + " :" + ht[obj]);
//    }
//    Console.WriteLine("Location" + " :" + ht["location"]);


//    //Console.WriteLine("is eid key exist or not");
//    // ht.ContainsKey("eid");
//    Console.WriteLine("is eid key exist or not" + ht.ContainsKey("r"));
//}
//    }





using System.Collections;

class Hash1
{

    static void Main(string[] args)
    {
        Stack st = new Stack();
        st.Push("deepti");
        st.Push("Amit");
        st.Push("ankit");
        Console.WriteLine(st.Count);
        Console.WriteLine(st.Peek());//display top element without removing it
        Console.WriteLine(st.Count);
        st.Pop();
        Console.WriteLine(st.Count);
        st.Pop();
        Console.WriteLine(st.Count);
        Console.WriteLine(st.Contains("Amit"));
        st.Push("Amit");
        st.Push("ankit");




        foreach (object ob in st)
        {
            Console.WriteLine(ob);
        }
    }
}





