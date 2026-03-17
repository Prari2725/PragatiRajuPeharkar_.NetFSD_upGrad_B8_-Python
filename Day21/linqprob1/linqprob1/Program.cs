
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Product
{
    public int ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Mrp { get; set; }
}

class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>()
        {
            new Product{ProductCode=101,ProductName="soap",Category="FMCG" ,Mrp=35},
            new Product{ProductCode=102,ProductName="Dal",Category="Grain" ,Mrp=20},
            new Product{ProductCode=103,ProductName="oil",Category="FMCG" ,Mrp=200},
            new Product{ProductCode=104,ProductName="Wheat",Category="Grain" ,Mrp=2000},
            new Product { ProductCode = 105, ProductName = "Sugar",  Category = "FMCG",  Mrp = 40 },
            new Product { ProductCode = 106, ProductName = "Rice",  Category = "Grain",  Mrp = 60}


        };

        //1.Write a LINQ query to search and display all products with category “FMCG”.
        var q1 = products.Where(p => p.Category == "FMCG");
        Console.WriteLine("1. FMCG Products");
        foreach (var p in q1) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }


        //2. Write a LINQ query to search and display all products with category “Grain”. 
        var q2 = products.Where(p => p.Category == "Grain");
        Console.WriteLine("\n 2.Grain Products");
        foreach (var p in q2) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }

        //3. Write a LINQ query to sort products in ascending order by product code. 
        var q3 = products.OrderBy(p => p.ProductCode);
        Console.WriteLine("\n 3.Asc order by pcode");
        foreach (var p in q3) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }

        //4. Write a LINQ query to sort products in ascending order by product Category. 
        var q4 = products.OrderBy(p => p.Category);
        Console.WriteLine("\n 4.Asc by category");
        foreach (var p in q4) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }

        //5.Write a LINQ query to sort products in ascending order by product Mrp.
        var q5 = products.OrderBy(p => p.Mrp);
        Console.WriteLine("\n 5.Asc by MRP");
        foreach (var p in q5) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }

        //6.Write a LINQ query to sort products in descending order by product Mrp.
        var q6 = products.OrderByDescending(p => p.Mrp);
        Console.WriteLine("\n 6.DSC by MRP");
        foreach (var p in q6) { Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}"); }

        //7.Write a LINQ query to display products group by product Category.
        var q7 = products.GroupBy(p => p.Category);
        Console.WriteLine("\n 7.Group by category");
        foreach (var group in q7)
        {
            Console.WriteLine("Category: " + group.Key);
            foreach (var p in group)
                Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Mrp}");
        }

        //8.Write a LINQ query to display products group by product Mrp. 
        var q8 = products.GroupBy(p => p.Mrp);
        Console.WriteLine("\n 8.group by mrp");
        foreach (var group in q8)
        {
            Console.WriteLine("Mrp: " + group.Key);
            foreach (var p in group)
                Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category}");
        }

        //9.Write a LINQ query to display product detail with highest price in FMCG category.

        var q9 = products
              .Where(p => p.Category == "FMCG")
              .OrderByDescending(p => p.Mrp).First();
        Console.WriteLine("\n 9.highest price in FMCG category\n");

       Console.WriteLine($"{q9.ProductCode} {q9.ProductName} {q9.Category} {q9.Mrp}");

        //10.Write a LINQ query to display count of total products.
        var q10 = products.Count();
        Console.WriteLine("\n 10.comt of total products\n" + q10);

        //11.Write a LINQ query to display count of total products with category FMCG. 
        var q11 = products.Count(p => p.Category == "FMCG");
        Console.WriteLine("\n11. Total FMCG Products = \n" + q11);

        //12.Write a LINQ query to display Max price.
        var q12 = products.Max(p => p.Mrp);
        Console.WriteLine("\n 12.Max price\n" + q12);

        //13.Write a LINQ query to display Min price.
        var q13 = products.Min(p => p.Mrp);
        Console.WriteLine("\n13. Min Price = \n" + q13);

        //14.Write a LINQ query to display whether all products are below Mrp Rs.30 or not. 
        var q14 = products.All(p => p.Mrp <30);
        Console.WriteLine("\n14. below Price = \n" + q14);



        //15.Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
        var q15 = products.Any(p => p.Mrp < 30);
        Console.WriteLine("\n15. above Price = \n" + q15);

    }

}