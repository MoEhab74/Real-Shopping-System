using System;
using System.Collections.Generic;
using System.Linq;

namespace RealShoppingSystem
{
    internal class SystemMangement
    {
        public static LinkedList<Product> Cart = new LinkedList<Product>();
        public static List<string> Favourite = new List<string>();
        public static Stack<string> Actions = new Stack<string>();
        public static List<IDictionary<string, double>> AllProducts = new List<IDictionary<string, double>>();

        public static void AddtoCart(Product product)
        {
            Cart.AddLast(product);
            Actions.Push($"added:{product.Name}");
        }
        public static void AddtoFavourite(string product)
        {
            Favourite.Add(product);
            Console.WriteLine($"Product {product} has been added to favourite\n");
            Actions.Push($"favourite:{product}");
        }
        public static void viewFavourites()
        {
            foreach (var item in Favourite)
            {
                Console.WriteLine($"Product: {item}");
            }
        }
        public static void RemovefromFavourite(string product)
        {
            if (Favourite.Any())
            {
                Favourite.Remove(product);
                Console.WriteLine($"Product {product} has been removed from favourite\n");
                Actions.Push($"unfavourite:{product}");
            }
            else
            {
                Console.WriteLine("There is no any product to remove from the favourite\n");
            }
        }
        public static void RemovefromCart(Product product)
        {
            if (Cart.Any())
            {
                Cart.Remove(product);
                Actions.Push($"removed:{product.Name}");
            }
            else  // if the cart is empty
            {
                Console.WriteLine("There is no element to remove or your cart is empty...");
            }
        }
        public static bool SearchInCart(string product)
        {
            foreach (var item in Cart)
            {
                if (item.Name == product)
                {
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public static void ViewCart()
        {
            if (Cart.Any())
            {
                Console.WriteLine("Here is your cart:");
                IEnumerable<Tuple<string, double>> itempricesCollection = GetTotalPrices();
                foreach (var item in itempricesCollection)
                {
                    Console.WriteLine($"Product:{item.Item1} , Price: {item.Item2}");
                }
            }
            else
            {
                Console.WriteLine("Now,your cart is empty");
            }

        }

        public static IEnumerable<Tuple<string, double>> GetTotalPrices()
        {
            var CartPrices = new List<Tuple<string, double>>();

            foreach (var item in Cart)
            {
                double value = 0;
                if (Mobiles.MobileGallery.TryGetValue(item.Name, out value) || Electronics.ElectronicGallery.TryGetValue(item.Name, out value)
                    || Perfumes.PerfumeGallery.TryGetValue(item.Name, out value))
                {
                    Tuple<string, double> tuple = new Tuple<string, double>(item.Name, value);
                    CartPrices.Add(tuple);
                }
            }
            return CartPrices;
        }
        public static Tuple<string, double> SearcforProduct(string ProductName)  // return tuble
        {
            //var SystemProducts = new Tuple<string,double>();
            Tuple<string, double> tuple;
            double value = 0;
            if (Mobiles.MobileGallery.TryGetValue(ProductName, out value) || Electronics.ElectronicGallery.TryGetValue(ProductName, out value)
                || Perfumes.PerfumeGallery.TryGetValue(ProductName, out value))
            {
                tuple = new Tuple<string, double>(ProductName, value);
                return tuple;
            }
            else
            {
                return null;
            }

        }

        public static double Checkout()
        {
            double totalPrice = 0;
            IEnumerable<Tuple<string, double>> ProductsPrices = GetTotalPrices();
            foreach (var item in ProductsPrices)
            {
                totalPrice += item.Item2;
            }
            return totalPrice;
        }

        public static double PaymentProcess(double value)
        {
            double reminder = 0;

            if (value == Checkout())
            {
                Console.WriteLine($"Process has done, your reminder is: {reminder}\n");
                Actions.Push($"paid:{value} recentely");

                return 0;
            }
            else if (value > Checkout())
            {
                reminder = value - Checkout();
                Console.WriteLine($"Process has done, your reminder is: {reminder}\n");
                Actions.Push($"paid:{value} recentely");
                return reminder;
            }
            while (Checkout() > value)
            {
                reminder = Checkout() - value;
                Console.WriteLine($"Your sum not enough, the reminder you must pay is: {reminder}\n");
                Actions.Push($"paid:{value} recentely");
                return reminder;
            }
            return reminder;
        }

        public static void UndolastAction()
        {
            if (Actions.Count == 0)
            {
                Console.WriteLine("There are no actions to undo");
            }
            else
            {
                string LastAction = Actions.Pop();
                var ActionArray = LastAction.Split(':');
                var ActionType = ActionArray[0];
                var action = ActionArray[1];
                if (ActionType == "added")
                {
                    foreach (var item in Cart)
                    {
                        if (item.Name == action)
                        {
                            Cart.Remove(item);
                            break;
                        }
                    }
                }
                else if (ActionType == "removed")
                {
                    foreach (var item in Cart)
                    {
                        if (item.Name == action)
                        {
                            Cart.AddLast(item);
                            break;
                        }
                    }
                }
                else if (ActionType == "favourite")
                {
                    foreach (var item in Favourite)
                    {
                        if (item == action)
                        {
                            Favourite.Remove(item);
                            break;
                        }
                    }
                }
                else if (ActionType == "unfavourite")
                {
                    foreach (var item in Favourite)
                    {
                        if (item == action)
                        {
                            Favourite.Add(item);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry check out and payment can't be undo ask for refund or send an email to us\n");
                }

            }
        }
    }
}
