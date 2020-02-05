using System;
using static System.Convert;
using static System.Console;
using System.Collections.Generic;
namespace Task5
{
    class GroceryStore
    {
        //public string store_name;
        static public float cash=0;        
        public static void sell(List<Product> list,int index)
        {
            try
            {
                cash += list[index].product_cost;
            }         
            catch(System.ArgumentOutOfRangeException)
            {
                WriteLine("----------------");
            }
            try
            { list.RemoveAt(index); }
            catch(System.ArgumentOutOfRangeException)
            {
                WriteLine("There's no products");
            }
            
        }
    }

}
