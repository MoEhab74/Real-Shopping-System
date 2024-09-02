using System;
using System.Linq;

namespace RealShoppingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t----------------------------Welcome to our Shopping System----------------------------");
            Console.WriteLine();
            Console.WriteLine("Sign up to start shopping:");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Email: ");
            string Email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string Phone = Console.ReadLine();
            User user = new User(Name, Email, Phone);
            Console.WriteLine();
            Console.WriteLine("Here is user information:");
            Console.WriteLine();
            user.ViewUserProfile();

            char choise;
            do
            {
                Console.WriteLine("If you want to update any information click yes");
                var response = Console.ReadLine().ToUpper()[0];
                if (response == 'y' || response == 'Y')
                {
                    Console.WriteLine();
                    user.UpdatemyInformation();
                    Console.WriteLine("Details after update:");
                    user.ViewUserProfile();
                    Console.WriteLine();
                }
                else if (response == 'N' || response == 'n')
                {
                    break;
                }

                Console.WriteLine("If you want to update any other information click yes");
                choise = Console.ReadLine()[0];

            } while (choise == 'y' || choise == 'Y');

            Console.WriteLine("User details has been saved");

            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            Console.WriteLine("\t\t----------------Here are all products----------------");
            Console.WriteLine();
            Product.DisplayAllProducts();
            Console.WriteLine();
            Console.WriteLine("If you want to add any product to your favourite click yes otherwise no:");
            var fav = Console.ReadLine();
            if (fav == "Yes" || fav == "yes")
            {
                string answer;
                do
                {
                    Console.Write("Enter the product name to add to favourite:");
                    string favProduct = Console.ReadLine();
                    if (Mobiles.MobileGallery.ContainsKey(favProduct) || Electronics.ElectronicGallery.ContainsKey(favProduct) || Perfumes.PerfumeGallery.ContainsKey(favProduct))
                    {
                        SystemMangement.AddtoFavourite(favProduct);
                    }
                    else
                    {
                        Console.WriteLine("Product not found in our system");
                    }
                    Console.WriteLine("If you want yo add other product to favourite click yes otherwise click no: ");
                    answer = Console.ReadLine();
                } while (answer == "Yes" || answer == "yes");

            }
            Console.WriteLine();
            Console.WriteLine("Here is your favourite list:\n");
            SystemMangement.viewFavourites();
            if (SystemMangement.Favourite.Any())
            {
                Console.WriteLine("\nIf you want to remove any thing from it click yes otherwise no: ");
                fav = Console.ReadLine();
                if (fav == "Yes" || fav == "yes")
                {
                    string answer;
                    do
                    {
                        Console.Write("Enter the item that you want to remove from favurite: ");
                        string Item = Console.ReadLine();
                        for (int i = 0; i < SystemMangement.Favourite.Count(); i++)
                        {
                            if (SystemMangement.Favourite[i] == Item)
                            {
                                SystemMangement.RemovefromFavourite(Item);
                            }

                        }
                        Console.WriteLine("\nHere is your favourite list:\n");
                        SystemMangement.viewFavourites();

                        Console.WriteLine("If you want to remove other product to favourite click yes otherwise click no: ");
                        answer = Console.ReadLine();
                        if (answer == "No" || answer == "no")
                            break;

                    } while (answer == "Yes" || answer == "yes");

                }
            }



            Console.WriteLine();


            // Make a loop for essential operations 
            char click;
            do
            {
                Console.WriteLine("Choose the type that you want >>> Mobiles , Electronics ,Perfumes");
                Console.Write("Enter your type: ");
                char type = Console.ReadLine().ToUpper()[0];
                Console.WriteLine();
                switch (type)
                {
                    case 'M': // Mobiles

                        Console.WriteLine("Here are all mobiles in our shopping system:\n");
                        Mobiles.Display();
                        Console.WriteLine("---------------");
                        Console.Write("Chose what you want >>> Add , Remove , Search:");
                        char myChoise = Console.ReadLine().ToUpper()[0];
                        switch (myChoise)
                        {
                            case 'A':
                                Console.Write("Enter the mobile name that you want: ");
                                string myMobile = Console.ReadLine();
                                Console.Write("Enter the mobile type: ");
                                string myType = Console.ReadLine();
                                Product mobile = new Mobiles(myMobile, myType);
                                if (Mobiles.MobileGallery.ContainsKey(myMobile))
                                {
                                    user.AddProduct(mobile);
                                    Console.WriteLine($"Product {mobile.Name} has been add successfuly");
                                    Console.Write("If you want to undo this action click yes othewise click no: ");
                                    char actionStatue = Console.ReadLine().ToUpper()[0];
                                    if (actionStatue == 'Y')
                                    {
                                        user.UndoAction();
                                        Console.WriteLine($"The last action of adding {mobile.Name} has been undo successfuly");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Unavailable product,try another one");
                                }
                                break;


                            case 'R':
                                if (SystemMangement.Cart.Any())
                                {
                                    Console.Write("Enter the mobile name to remove: ");
                                    myMobile = Console.ReadLine();
                                    if (Mobiles.MobileGallery.ContainsKey(myMobile))
                                    {
                                        foreach (var item in SystemMangement.Cart)
                                        {
                                            if (item.Name == myMobile)
                                            {
                                                user.RemoveProduct(item);
                                                Console.WriteLine($"Product {item.Name} has been removed successfuly");
                                                Console.Write("If you want to undo this action click yes othewise click no: ");
                                                char actionStatue = Console.ReadLine().ToUpper()[0];
                                                if (actionStatue == 'Y' || actionStatue == 'y')
                                                {
                                                    user.UndoAction();
                                                    Console.WriteLine($"The last action of removing {item.Name} has been undo successfuly");
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("Product not found");
                                }
                                break;

                            case 'S':
                                Console.Write("Enter the mobile name to search: ");
                                myMobile = Console.ReadLine();
                                Tuple<string, double> SearchedProduct = SystemMangement.SearcforProduct(myMobile);
                                if (SearchedProduct != null)
                                {
                                    Console.WriteLine($"Product: {SearchedProduct.Item1} , Price: {SearchedProduct.Item2}");
                                }
                                else
                                {
                                    Console.WriteLine("Product not founded");
                                }

                                break;
                        } // Entire Switch for Add,Remove and search for mobile

                        break;


                    case 'E': // Electronics

                        Console.WriteLine("Here are all Electronics in our shopping system:");
                        Electronics.Display();
                        Console.WriteLine("---------------");
                        Console.Write("Chose what you want >>> Add , Remove , Search:");
                        myChoise = Console.ReadLine().ToUpper()[0];
                        switch (myChoise)
                        {
                            case 'A':
                                Console.Write("Enter the Device name that you want: ");
                                string myDevice = Console.ReadLine();
                                Console.Write("Enter the device type: ");
                                string myType = Console.ReadLine();
                                Product device = new Electronics(myDevice, myType);
                                if (Electronics.ElectronicGallery.ContainsKey(myDevice))
                                {
                                    user.AddProduct(device);
                                    Console.WriteLine($"Product {device.Name} has been added successfuly");
                                    Console.Write("If you want to undo this action click yes othewise click no: ");
                                    char actionStatue = Console.ReadLine().ToUpper()[0];
                                    if (actionStatue == 'Y' || actionStatue == 'y')
                                    {
                                        user.UndoAction();
                                        Console.WriteLine($"The last action of adding {device.Name} has been undo successfuly");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Unavailable product,try another one");
                                }
                                break;


                            case 'R':
                                if (SystemMangement.Cart.Any())
                                {
                                    Console.Write("Enter the device name to remove: ");
                                    myDevice = Console.ReadLine();
                                    if (Electronics.ElectronicGallery.ContainsKey(myDevice))
                                    {
                                        foreach (var item in SystemMangement.Cart)
                                        {
                                            if (item.Name == myDevice)
                                            {
                                                user.RemoveProduct(item);
                                                Console.WriteLine($"Product {item.Name} has been removed successfuly");
                                                Console.Write("If you want to undo this action click yes othewise click no: ");
                                                char actionStatue = Console.ReadLine().ToUpper()[0];
                                                if (actionStatue == 'Y' || actionStatue == 'y')
                                                {
                                                    user.UndoAction();
                                                    Console.WriteLine($"The last action of removing {item.Name} has been undo successfuly");
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product not found");
                                    }
                                }


                                break;

                            case 'S':
                                Console.Write("Enter the device name to search: ");
                                string MyDevice = Console.ReadLine();
                                Tuple<string, double> SearchedProduct = SystemMangement.SearcforProduct(MyDevice);
                                if (SearchedProduct != null)
                                {
                                    Console.WriteLine($"Product: {SearchedProduct.Item1} , Price: {SearchedProduct.Item2}\n");
                                }
                                else
                                {
                                    Console.WriteLine("Product not founded");
                                }

                                break;
                        } // Entire Switch for Add,Remove and search for electronics

                        break;



                    case 'P': // Perfumes

                        Console.WriteLine("Here are all Perfumes in our shopping system:");
                        Perfumes.Display();
                        Console.WriteLine("---------------");
                        Console.Write("Chose what you want >>> Add , Remove , Search:");
                        myChoise = Console.ReadLine().ToUpper()[0];
                        switch (myChoise)
                        {
                            case 'A':
                                Console.Write("Enter the perfume name that you want: ");
                                string myPerfume = Console.ReadLine();
                                Console.Write("Enter the perfume type: ");
                                string myType = Console.ReadLine();
                                Product perfume = new Perfumes(myPerfume, myType);
                                if (Perfumes.PerfumeGallery.ContainsKey(myPerfume))
                                {
                                    user.AddProduct(perfume);
                                    Console.WriteLine($"Product {perfume.Name} has been added successfuly");
                                    Console.Write("If you want to undo this action click yes othewise click no: ");
                                    char actionStatue = Console.ReadLine().ToUpper()[0];
                                    if (actionStatue == 'Y' || actionStatue == 'y')
                                    {
                                        user.UndoAction();
                                        Console.WriteLine($"The last action of adding {perfume.Name} has been undo successfuly\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Unavailable product,try another one");
                                }
                                break;


                            case 'R':
                                if (SystemMangement.Cart.Any())
                                {
                                    Console.Write("Enter the perfume name to remove: ");
                                    myPerfume = Console.ReadLine();
                                    if (Perfumes.PerfumeGallery.ContainsKey(myPerfume))
                                    {
                                        foreach (var item in SystemMangement.Cart)
                                        {
                                            if (item.Name == myPerfume)
                                            {
                                                user.RemoveProduct(item);
                                                Console.WriteLine($"Product {item.Name} has been removed successfuly");
                                                Console.Write("If you want to undo this action click yes othewise click no: ");
                                                char actionStatue = Console.ReadLine().ToUpper()[0];
                                                if (actionStatue == 'Y' || actionStatue == 'y')
                                                {
                                                    user.UndoAction();
                                                    Console.WriteLine($"The last action of removing {item.Name} has been undo successfuly");
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("Product not found");
                                }
                                break;

                            case 'S':
                                Console.Write("Enter the mobile name to search: ");
                                string MyPerfume = Console.ReadLine();
                                Tuple<string, double> SearchedProduct = SystemMangement.SearcforProduct(MyPerfume);
                                if (SearchedProduct != null)
                                {
                                    Console.WriteLine($"Product: {SearchedProduct.Item1} , Price: {SearchedProduct.Item2}");
                                }
                                else
                                {
                                    Console.WriteLine("Product not founded");
                                }

                                break;
                        } // Entire Switch for Add,Remove and search for perfumes

                        break;

                    default:
                        Console.WriteLine("These type of product doesn't exist in our shopping system\n");
                        break;
                }
                Console.Write("If you want to do anything else click yes:");
                click = Console.ReadLine().ToUpper()[0];
            } while (click == 'Y' || click == 'y');

            // After the user finish operation he will see his Cart


            if (SystemMangement.Cart.Count > 0)
            {
                user.DisplayCsrt();
                Console.WriteLine();
                Console.Write("Click next to go to the check out: ");
                string next = Console.ReadLine();
                if (next == "next")
                {
                    Console.WriteLine($"Here is the total price: {user.Checkout()}");
                    Console.WriteLine($"Enter the sum {user.Checkout()} to complete the payment process");
                    double Total = double.Parse(Console.ReadLine());
                    user.Payment(Total);

                    Console.Write("If you want to undo this action click yes othewise click no: ");
                    char actionStatue = Console.ReadLine().ToUpper()[0];
                    if (actionStatue == 'Y' || actionStatue == 'y')
                    {
                        user.UndoAction();
                    }

                    SystemMangement.Cart.Clear();
                    SystemMangement.ViewCart();

                    Console.WriteLine("Thanks for your trust in our shopping system, hope to repeat the visit");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }

            Console.ReadLine();
        }
    }
}
