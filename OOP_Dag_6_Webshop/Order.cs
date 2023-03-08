using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dag_6_Webshop
{
    internal class Order
    {
        //Product
        //Amounts of Products
        //Total Price
        //DateTime when order is placed
        //Paid
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Products> ProductOrders { get; set; } = new();
        public double TotalPrice { get; set; }
        public Address DeliveryAddress { get; set; }
        public DateTime Created { get; set; }
        public bool IsPaid { get; set; }

        public Order() { }
        public Order (Customer customer, List<Products> productOrders, double totalPrice, Address deliveryaddress, DateTime created, bool isPaid)
        {
            Customer = customer;
            ProductOrders = productOrders;
            TotalPrice = totalPrice;
            DeliveryAddress = deliveryaddress;
            Created = created;
            IsPaid = isPaid;
        }
         public void CreateOrder()
        {
            //Create orders.
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\n*** ORDER DETAILS ***");
            Console.CursorVisible = true;
            Console.Write("\n\nWhich Customer is this?: ");
            string Custname = Console.ReadLine();

            Console.Write("\nWhat is the street name: ");
            string StreetName = Console.ReadLine();

            Console.Write("\nWhat is the Street Number: ");
            string StreetNumber = Console.ReadLine();

            Console.Write("\nWhat is the city Name: ");
            string City = Console.ReadLine();

            Console.Write("\nWhat is the postalCode: ");
            //Write Propeties from address class
            string postalCode = Console.ReadLine();

            Console.Write("\nWhat is the Country you live in?");
            string country = Console.ReadLine();

            Console.Write("Have you already paid? Write 'Y' for yes");
            string IsTrueOrFalse = Console.ReadLine();
            bool Paid;
            if (IsTrueOrFalse == "y" || IsTrueOrFalse == "Y")
                Paid = true;
            else 
                Paid = false;

            Address address = new(StreetName, Convert.ToInt32(StreetNumber), City, Convert.ToInt32(postalCode), country);
            foreach (var item in Data.CustomerList)
            {
                if (item.Name == Custname)
                {
                    Customer = item;
                    //ProductList should be here already.
                    //Total price is already calculated
                    DeliveryAddress = address;
                    Created = DateTime.Now;
                    IsPaid = Paid;
                    Data.OrderList.Add(this);
                    Console.WriteLine("Customer Found.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Customer not found");
                    Console.ReadLine();
                }
            }

        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new();
            foreach (var item in ProductOrders)
            {//Takes all the names so it can be Written.
                stringBuilder.Append("\n "+item.ToString());
            }
            return $"{Customer.Name}\nProducts:{stringBuilder}\nTotal Price: {TotalPrice}\nAddress:{DeliveryAddress}\nCreated:{Created}\nIs it paid:{IsPaid}";
        }
    }
}
