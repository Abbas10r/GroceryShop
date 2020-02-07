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
        //--------------------------------------------------------------------------------------------------
        static void delete_product(List<Product> list)
        {
            WriteLine("Enter index of a product: ");
            int index = ToInt32(ReadLine());
            try
            {
                list.RemoveAt(index);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                WriteLine("There's no products");
            }
        }
        //-----------------------------------------------------------------------------------------------
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
            WriteLine("Enter amount of products ");
            int amount = 0;
            try
            {
                amount = ToInt32(ReadLine());
            }
            catch(System.FormatException)
            {
                WriteLine("You've entered a wrong value");
            }          
            for(int i=0;i<amount;i++)
            {
                string nname = $"{name}({i})";
                Product p1 = new Product(nname, cost);
                list.Add(p1);
            }           
        }
        //----------------------------------------------------------------------------------------------
        static void show_list(List<Product> list)
        {
            int counter = 0;
            bool isEmpty = IsEmpty(list);

            if (isEmpty)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                foreach (Product item in list)
                {
                    Console.WriteLine("index - " + counter + " " + item.product_name + " - " + item.product_cost+" som");
                    counter++;
                }
            }
        }
        //----------------------------------------------------------------------------------------------
        static void sort_list(List<Product> list)
        {
            var byCost = from u in list
                         orderby u.product_cost descending //from higher to lower. Can remove "descending" for reverse sort
                         select u;
            Console.WriteLine("Ordered by cost");
            foreach (Product item in byCost)
                Console.WriteLine(item.product_cost + " som - " + item.product_name);
        }
        //----------------------------------------------------------------------------------------------
        static void sell_product(List<Product> list)
        {
            int i = 0;
            WriteLine("Enter index of a product");
            try
            {
                i = int.Parse(ReadLine());
            }                      
            catch(System.FormatException)
            {
                WriteLine("You've intered a wrong value");
            }
            GroceryStore.sell(list, i);
        }
        //----------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {                      
            bool turnon=true;
            List<Product> products_list = new List<Product>();
            WriteLine("          Welcome to Abbas's Grocery Shop!");
            WriteLine("         ---------------------------------");
            while (turnon)
            {
                WriteLine("          Enter 1 to add product to shop.\n" +
                    "          Enter 2 to remove a product\n"+
                "          Enter 3 to see a list of products.\n" +
                "          Enter 4 to sell a product.\n"+
                "          Enter 5 to sort a list.\n" +
                "          Enter 6 to check a cashbox\n" +
                "          Enter 0 to close a program.");
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
                        delete_product(products_list);
                        break;
                    case 3:
                        show_list(products_list);
                        break;
                    case 4:
                        sell_product(products_list);
                        break;
                    case 5:
                        sort_list(products_list);
                        break;
                    case 6:
                        WriteLine($"Money amount in cashbox - {GroceryStore.cash} som");
                        break;
                    default:
                        WriteLine("You've Entered a wrong button");
                        break;
                }
            }         
        }
    }
}
