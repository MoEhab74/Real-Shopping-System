using System.Collections.Generic;

namespace RealShoppingSystem
{
    internal class Mobiles : Product
    {
        // Collection of mobiles
        public static Dictionary<string, double> MobileGallery = new Dictionary<string, double>
        {
            {"iphone14",1500 },{"iphone15",1700},{"iphone16",2000},
            {"samsungS21",1600 },{"sansungS22",2150},{"samsungS20",1000},
            {"redmiP10",950 },{"redmiP9",700},{"redmiP30",1300},
        };

        public Mobiles()
        {

        }
        public Mobiles(string name, string type)
        {
            this.Name = name; this.Type = type;
        }

        public static void Display()
        {
            Product.Display(MobileGallery);
        }


    }
}
