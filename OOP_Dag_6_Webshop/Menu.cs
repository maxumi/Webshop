using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dag_6_Webshop
{
    internal class Menu
    {
        public Data data = new();//Makes an instance of the data class.
        public void MainMenu()//Runs the mainMenu method
        {
            Console.CursorVisible = false;//Don't show the "Cursor", AKA the blinking line.

            List<string> list = new() { "Show products", "Show Customers","Product orders", "Shopping Cart" };
            switch (ShowMenu("\n*** Main Menu*** \n", list))//Shows the two strings of above.
            {// Gets the returned value from ShowMenu which then selects a case.
                case 0:
                    ShowProducts();
                    break;
                case 1:
                    ShowCustomers();
                    break;
                case 2:
                    ShowProductOrders();
                    break;
                case 3:
                    ShowShoppingCart();
                    break;
                default:
                    break;
            }
        }
        public void LoginScreen()
        {
            List<string> list = new() { "Login", "Create Customer Account." };
            switch (ShowMenu("\n*** Create Customer Account or Login*** \n", list))
            {
                case 0:
                    Customer customer1 = new Customer();//New instance of customer
                    bool FalseOrTrue  = customer1.LoginToCustomerAccount();
                    if (FalseOrTrue == false)
                        LoginScreen();
                    break;
                case 1:
                    Customer customer2= new Customer();//New instance of customer
                    customer2.CreateCustomerAccount();
                    break;
                default:
                    break;
            }
        }

        private void ShowCustomers()
        {
            List<string> cust = new();//Makes a new list of strings.
            foreach (var item in Data.CustomerList)
                cust.Add(item.ToString());//Creates strings of the customers in the list.
            ShowMenu("SHOW CUSTOMERS", cust);
            MainMenu();
        }

        private void ShowProducts()
        {
            List<string> prod = new();//Makes a new list of strings.
            foreach (var item in Data.ProductsList)
                prod.Add(item.ToString());//Creates strings of the products in the list.

            int select = ShowMenu("SHOW PRODUCTS", prod);//Gets the returned value from ShowMenu.
            foreach (Products item in Data.ProductsList)
            {
                if (Data.ProductsList.IndexOf(item) == select)
                {
                    Console.WriteLine("Price: " + item.Price+"Kr.");//Shows price
                    Console.WriteLine("Do you want to Add it to your shopping cart?");
                    Console.WriteLine("Press Y for yes, and Everything else for No");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Y)
                    {
                        Data.ShoppingCart.ProductOrders.Add(item);
                        Console.WriteLine("\nAdded to your shopping cart");
                    }
                    else
                    {
                        Console.WriteLine("Not added to your shopping cart");
                    }
                    Console.ReadLine();
                    MainMenu();
                }
            }
        }
        public void ShowProductOrders()
        {
            List<string> ordr = new();
            foreach (var item in Data.OrderList)
                ordr.Add(item.ToString());
            ShowMenu("SHOW ORDERS", ordr);
            MainMenu();
        }
        public void ShowShoppingCart()
        {
            List<string> ordr = new();
            foreach (var item in Data.ShoppingCart.ProductOrders)
                ordr.Add(item.ToString());
            int select = ShowMenu("\n*** Shopping Cart *** \n", ordr);
            //Show price
            double price = 0;
            foreach (var item in Data.ShoppingCart.ProductOrders)
            {
                price += item.Price;
            }
            Console.WriteLine("Total Price: " + price + "Kr.");
            //Console.WriteLine("Do you want to remove This Item from your shopping cart?");
            //Console.WriteLine("Press Y for yes, and Everything else for No");
           Console.WriteLine("1. Remove Item, 2. Finilize Order.");
            foreach (Products item in Data.ShoppingCart.ProductOrders)
            {
                if (Data.ShoppingCart.ProductOrders.IndexOf(item) == select)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)
                    {
                        Data.ShoppingCart.ProductOrders.Remove(item);
                        Console.WriteLine("Removed from your shopping cart");
                        Console.ReadLine();
                    }
                    //Next if for finilize order
                    else if (key.Key == ConsoleKey.D2)
                    {
                        Data.ShoppingCart.CreateOrder();
                    }

                    else
                    {
                        Console.WriteLine("Not removed from your shopping cart");
                        Console.ReadLine();
                    }
                    MainMenu();
                }
            }
            MainMenu();
        }

        public int ShowMenu(string Headline, List<string> menuItems)
        {
            //Shows list of menu items, and highlights selected item
            int selected = 0;//The begining number is 0.
            while (true)//Continues as long as its true.
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(Headline);//Writes the headline.

                foreach (var item in menuItems)//Each MenuItems(could be products).
                {
                    if (menuItems.IndexOf(item) == selected)//IndexOf means something like the first is "0".
                    {//Changes it to the main color
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {//This is the not selected background.
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.WriteLine(item);//Writes the actual item/Product.
                }

                ConsoleKey ck = Console.ReadKey().Key;//Uses Arrow keys to select.

                if (ck == ConsoleKey.UpArrow)
                {
                    selected--;
                    if (selected < 0) selected = menuItems.Count - 1;//If you go up, it will go to the last item.
                }
                else if (ck == ConsoleKey.DownArrow)
                {
                    selected++;
                    if (selected >= menuItems.Count) selected = 0;// If you go down, it will go to the first item.
                }
                else if (ck == ConsoleKey.Enter || ck == ConsoleKey.Spacebar) 
                { 
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    return selected; 
                }// If you press enter or spacebar, it will return the selected item.

            }

        }
    }
}
