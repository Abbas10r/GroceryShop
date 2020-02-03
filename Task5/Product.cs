using System;
using static System.Convert;
using static System.Console;

namespace Task5
{
    class Product : GroceryStore
    {
        public string product_name { get; set; } = "product0";
        public float product_cost { get; set; } = 10;
        public Product() { }
        public Product(string product_name,float product_cost)
        {
            this.product_name = product_name;
            this.product_cost = product_cost;        
        }       
    }
}
