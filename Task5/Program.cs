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
            List<Product> products_list = new List<Product>();
            Product bread = new Product("bread",20.00f);
            Product banana = new Product("banana", 30.00f);
            Product snickers = new Product();
            snickers.product_name = "snickers";
            snickers.product_cost = 40;
            products_list.Add(snickers);
            products_list.Add(bread);
            products_list.Add(banana);
            /*foreach (Product item in products_list)
               Console.WriteLine(item.product_name);*/
            var byCost = from u in products_list
                         orderby u.product_cost descending //from higher to lower. Can remove "descending" for reverse sort
                         select u;
            Console.WriteLine("Ordered by cost");
            foreach (Product item in byCost)
                Console.WriteLine(item.product_cost + " - " + item.product_name);
        }
    }
}
