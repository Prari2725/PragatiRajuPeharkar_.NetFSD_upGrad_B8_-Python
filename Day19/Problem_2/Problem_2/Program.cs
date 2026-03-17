//using System.Collections;

//class Hash1
//{

//    static void Main(string[] args)
//    {
//        Stack st = new Stack();
//        st.Push(10);
//        st.Push(20);
//        st.Push(30);
//        st.Push(40);
//        st.Push(50);
//        Console.WriteLine(st.Count);
//        Console.WriteLine(st.Peek());
//        Console.WriteLine(st.Count);
//        st.Pop();
//        Console.WriteLine(st.Count);
//        st.Pop();
//        Console.WriteLine(st.Count);
//        Console.WriteLine(st.Contains(60));
//        st.Push(60);
//        st.Push(70);




//        foreach (object ob in st)
//        {
//            Console.WriteLine(ob);
//        }
//    }
//}


using System;
using System.Collections.Generic;

class Program
{
    static void DisplayState(Stack<string> stack)
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("Current State: Empty");
        }
        else
        {
            Console.Write("Current State: ");

            foreach (string action in stack)
            {
                Console.Write(action + " ");
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        Stack<string> st = new Stack<string>();
        int choice;

        do
        {
            Console.WriteLine("\n1. Type Action");
            Console.WriteLine("2. Undo");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter action: ");
                    string action = Console.ReadLine();
                    st.Push(action);
                    Console.WriteLine("Action Added.");
                    DisplayState(st);
                    break;

                case 2:
                    if (st.Count == 0)
                    {
                        Console.WriteLine("Nothing to undo.");
                    }
                    else
                    {
                        Console.WriteLine("Undo Action: " + st.Pop());
                        DisplayState(st);
                    }
                    break;

                case 3:
                    Console.WriteLine("Program Ended.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 3);
    }
}