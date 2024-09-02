using System.Collections.Generic;

namespace RealShoppingSystem
{
    internal class Electronics : Product
    {
        public static Dictionary<string, double> ElectronicGallery = new Dictionary<string, double>
        {
            {"smartTV",1500 },{"TV",700},{"Fan",200},
            {"Laptop",1600 },{"PC",2150},{"microwiv",1000},
        };
        public Electronics(string name, string type)
        {
            this.Name = name; this.Type = type;
        }
        public static void Display()
        {
            Product.Display(ElectronicGallery);
        }
    }
}
