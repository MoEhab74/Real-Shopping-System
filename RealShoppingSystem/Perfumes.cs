using System.Collections.Generic;

namespace RealShoppingSystem
{
    internal class Perfumes : Product
    {
        public static Dictionary<string, double> PerfumeGallery = new Dictionary<string, double>
        {
            {"Chanel",50 },{"Doir",70},{"Tom ford",20},
            {"Danhel",60 },{"Zara",150},{"Versace",100},
        };
        public Perfumes(string name, string type)
        {
            this.Name = name; this.Type = type;
        }
        public static void Display()
        {
            Product.Display(PerfumeGallery);
        }
    }
}
