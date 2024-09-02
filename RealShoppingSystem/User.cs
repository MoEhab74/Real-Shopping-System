using System;

namespace RealShoppingSystem
{
    internal class User
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        public User(string name, string email, string phone)
        {
            this.Name = name; this.Email = email; this.Phone = phone;
        }

        public void UpdatemyInformation()
        {
            Console.Write("Enter what You want to update: ");
            char answer = Console.ReadLine().ToUpper()[0];
            switch (answer)
            {
                case 'N':
                    Console.Write("Enter your new name: ");
                    this.Name = Console.ReadLine();
                    break;
                case 'E':
                    Console.Write("Enter your new Email: ");
                    this.Email = Console.ReadLine();
                    break;
                case 'P':
                    Console.Write("Enter your new phone number: ");
                    this.Phone = Console.ReadLine();
                    break;
            }
        }

        public void ViewUserProfile()
        {
            Console.WriteLine($"User Name: {this.Name}\nUser Email: {this.Email}\nUser Phone: {this.Phone}");
        }

        public void AddProduct(Product product)
        {
            SystemMangement.AddtoCart(product);
        } // Add product
        

        public void RemoveProduct(Product product)
        {
            SystemMangement.RemovefromCart(product);
        } // Remove product

        public bool SearchinCart(string product)
        {
            return SystemMangement.SearchInCart(product);
        }
        public void SearchForProduct(string ProductName)
        {
            SystemMangement.SearcforProduct(ProductName);
        }

        public void DisplayCsrt()
        {
            SystemMangement.ViewCart();
        }

        public double Checkout()
        {
            return SystemMangement.Checkout();
        }

        public double Payment(double value)
        {
            return SystemMangement.PaymentProcess(value);
        }

        public void UndoAction()
        {
            SystemMangement.UndolastAction();
        }

    }
}
