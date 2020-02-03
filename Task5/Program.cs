using System;
using static System.Convert;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool turnon=true;
            List<Product> products_list = new List<Product>();
            WriteLine("Welcome to Abbas's Grocery Shop!");           
            while (turnon)
            {
                WriteLine("Press 1 to add groceries to shop.\n" +
                "Press 2 to see a list of products.\n" +
                "Press 3 to sort a list.\n" +
                "Press 0 to close a program.");
                int button = ToInt32(ReadLine());              
                switch (button)
                {
                    case 0:
                        turnon = false;
                        break;
                    case 1:
                        WriteLine("Type a name of product: ");
                        string name = ReadLine();
                        WriteLine("Type a cost of product: ");
                        float cost = float.Parse(ReadLine());
                        Product p1 = new Product(name,cost);
                        products_list.Add(p1);
                        break;
                    case 2:
                        foreach (Product item in products_list)
                            Console.WriteLine(item.product_name + " - "+item.product_cost);
                        break;
                    case 3:
                        var byCost = from u in products_list
                                     orderby u.product_cost descending //from higher to lower. Can remove "descending" for reverse sort
                                     select u;
                        Console.WriteLine("Ordered by cost");
                        foreach (Product item in byCost)
                            Console.WriteLine(item.product_cost + " - " + item.product_name);
                        break;
                    default:
                        WriteLine("You've pressed a wrong button");
                        break;
                }
            }
            
        }
    }
}
