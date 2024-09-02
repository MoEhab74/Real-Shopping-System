using System;
using System.Collections.Generic;

namespace RealShoppingSystem
{
    internal abstract class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public static void Display(IDictionary<string, double> Products) // Display any Collecton
        {
            foreach (var item in Products)
            {
                Console.WriteLine($"Product: {item.Key} , Price: {item.Value}");
            }
        }
        public static void DisplayAllProducts()  // Display all products
        {
            
            Console.WriteLine("-----------------Mobile phones-----------------");
            Console.WriteLine();
            Mobiles.Display();
            Console.WriteLine();
            Console.WriteLine("-----------------Electronics-------------------");
            Console.WriteLine();
            Electronics.Display();
            Console.WriteLine();
            Console.WriteLine("-----------------Perfumes----------------------");
            Console.WriteLine();
            Perfumes.Display();
            
            Console.WriteLine("-----------------------");
        }

    }
}
