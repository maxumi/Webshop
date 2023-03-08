using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dag_6_Webshop
{
    internal class Data //Adds data to the list
    {
        public static List<Products> ProductsList = new List<Products>();//List of products.
        public static List<Customer> CustomerList = new List<Customer>();//List of customers.
        public static List<Order> OrderList = new List<Order>();//List of orders.
        public static Order ShoppingCart = new();
        public Data()//Constructor that automaticly runs AddProducts.
        {
            AddProducts();
            AddCustomers();
            AddOrders();

        }
        public void AddProducts()//Inserts Data in the form of "Products" Class.
        {
            ProductsList.Add(new Products("Nvidia RTX4090", 12000, 15999, 4, "The Best money can get. Can play minesweeper in 8K!", ProductsType.GPU));
            ProductsList.Add(new Products("Radeon RX 6700 XT", 3000, 4999, 4000, "Good Value for money. Almost always FPS>1", ProductsType.GPU));
            ProductsList.Add(new Products("Ryzen 9 5900X", 4000, 6999, 10, "The best CPU for gaming. Not that good for work, but who cares about work?", ProductsType.CPU));
            ProductsList.Add(new Products("Intel i9 10900K", 3000, 5999, 20, "The best CPU for work. Not that good for gaming, but who cares about gaming?", ProductsType.CPU));
            ProductsList.Add(new Products("ASUS ROG STRIX B550-F GAMING", 2000, 2999, 200, "The best motherboard for gaming. Not that good for work, but who cares about work?", ProductsType.Motherboard));
            ProductsList.Add(new Products("MSI MPG Z490 GAMING PLUS", 1500, 2499, 500, "The best motherboard for work. Not that good for gaming, but who cares about gaming?", ProductsType.Motherboard));
            ProductsList.Add(new Products("Corsair Vengeance LPX 32GB (2x16GB) DDR4 3600MHz", 2000, 2999, 1000, "The best RAM for gaming. Not that good for work, but who cares about work?", ProductsType.RAM));
            ProductsList.Add(new Products("Crucial Ballistix 32GB (2x16GB) DDR4 3600MHz", 1500, 2499, 1000, "The best RAM for work. Not that good for gaming, but who cares about gaming?", ProductsType.RAM));
            ProductsList.Add(new Products("WD Blue 1TB M.2-2280 NVMe SSD", 1000, 1499, 2000, "The best SSD for gaming. Not that good for work, but who cares about work?", ProductsType.SSD));
            ProductsList.Add(new Products("Samsung 970 EVO Plus 1TB M.2-2280 NVMe SSD", 800, 1299, 3000, "The best SSD for work. Not that good for gaming, but who cares about gaming?", ProductsType.SSD));
        }
        public void AddCustomers()
        {
            //Create address
            Address address1 = new Address()
            {
                StreetName = "Streety",
                StreetNumber = 2452,
                City = "København",
                PostalCode = 256,
                Country = "Denmark"
            };
            Address address2 = new Address()
            {
                StreetName = "Kælkevej",
                StreetNumber = 1234,
                City = "Aalborg",
                PostalCode = 016,
                Country = "Denmark"
            };
            CustomerList.Add(new Customer(0,"Max", "Max@gmail.com", "18233400", address1));
            CustomerList.Add(new Customer(1,"Jakob","Jakob@gmail.com","247543",address2));
        }
        public void AddOrders()
        {
            //Write code that gets the first Customer from customerlist.
            Customer cust1 = CustomerList[0];
            Customer cust2 = CustomerList[1];
            
            // Write Code that get some products.
            Products prod1 = ProductsList[4];
            Products prod2 = ProductsList[5];
            Products prod3 = ProductsList[2];
            List<Products> OrdProdList1 = new List<Products>
            {
                prod1,
                prod2,
                prod3
            };

            Products prod11 = ProductsList[3];
            Products prod12 = ProductsList[0];
            Products prod13 = ProductsList[1];
            List<Products> OrdProdList2 = new List<Products>
            {
                prod11,
                prod12,
                prod13
            };

            //Total Price
            double price1=0;
            foreach (Products products in OrdProdList1)
            {
                price1 += products.Price;
            }
            double price2 = 0;
            foreach (Products products in OrdProdList2)
            {
                price2 += products.Price;
            }


            //Delivery Address
            Address add1 = cust1.HomeAdress;
            Address add2 = cust2.HomeAdress;

            OrderList.Add(new Order (cust1, OrdProdList1, price1, add1, DateTime.Now,true));
            OrderList.Add(new Order(cust2, OrdProdList2, price2, add2, DateTime.Now, false));

        }
    }
}
