using System;
using static System.Convert;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace Task5
{
    class Program
    {
        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }
        static void adding_product(List<Product> list)
        {
            WriteLine("Enter a name of product: ");
            string name = ReadLine();
            float cost = 0;
            WriteLine("Enter a cost of product: ");
            try
            {
                cost = float.Parse(ReadLine());
            }
            catch (System.FormatException)
            {
                WriteLine("You've Entered a wrong value.");
            }
            Product p1 = new Product(name, cost);
            list.Add(p1);
        }
        static void Main(string[] args)
        {
            bool turnon=true;
            List<Product> products_list = new List<Product>();
            WriteLine("Welcome to Abbas's Grocery Shop!");           
            while (turnon)
            {
                WriteLine("Enter 1 to add product to shop.\n" +
                    "Enter 2 to remove a product\n"+
                "Enter 3 to see a list of products.\n" +
                "Enter 4 to sort a list.\n" +
                "Enter 0 to close a program.");
                int button = 0;
                try
                {
                    button = ToInt32(ReadLine());
                }                  
                catch(System.FormatException)
                {
                    WriteLine("You've Entered a wrong value.");
                }            
                switch (button)
                {
                    case 0:
                        turnon = false;
                        break;
                    case 1:
                        adding_product(products_list);
                        break;
                    case 2:
                        WriteLine("Enter index of a product: ");
                        int index = ToInt32(ReadLine());
                        products_list.RemoveAt(index);
                        break;
                    case 3:
                        int counter = 0;
                        bool isEmpty = IsEmpty(products_list);

                        if (isEmpty)
                        {
                            Console.WriteLine("List is Empty");
                        }
                        else
                        {
                            foreach (Product item in products_list)
                            {
                                Console.WriteLine("index - " + counter + " " + item.product_name + " - " + item.product_cost);
                                counter++;
                            }
                        }
                        break;
                    case 4:
                        var byCost = from u in products_list
                                     orderby u.product_cost descending //from higher to lower. Can remove "descending" for reverse sort
                                     select u;
                        Console.WriteLine("Ordered by cost");
                        foreach (Product item in byCost)
                            Console.WriteLine(item.product_cost + " - " + item.product_name);
                        break;
                    default:
                        WriteLine("You've Entered a wrong button");
                        break;
                }
            }
            
        }
    }
}
