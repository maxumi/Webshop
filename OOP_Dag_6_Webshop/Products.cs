using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dag_6_Webshop
{
    enum ProductsType { GPU, CPU, Motherboard, RAM, SSD, Moniter, PSU, Case, Cooling }//Diffrent types of products.
    internal class Products
    {
        public int ProductId { get; set; } //ID
        public string? Name { get; set; }//Name
        public int Stock { get; set; }//How much of it.
        public ProductsType ProductsType { get; set; }//What type of product it is.
        public string? Description {get; set; }//The Description of it
        public double StockPrice {get; set; } //Price of what the webshop bought it for
        private double price;
        public double Price //The price it is for the customers.
        {
            get
            { return price; }//Gets private price

            set
            {
                if (value < StockPrice)//If the private price is lower than stockprice, trow new exeption.
                {
                    throw new Exception("Price too low. We need to MAKE money not LOSE money!");
                }
                else
                {
                    price = value;//If not, set the price to the value.
                }
            }
        }
        public Products() { }//Base Constructor. Below is the one with variables.
        public Products(string name, double stockPrice, double price, int stock, string description, ProductsType productType)
        {
            Name = name;
            StockPrice = stockPrice;
            Price = price;
            Stock = stock;
            Description = description;
            ProductsType = productType;

        }
        public override string ToString()//When using ToString, it writes something diffrent.
        {
            return $"{Name} {Price} {ProductsType}";
        }
    }

}
