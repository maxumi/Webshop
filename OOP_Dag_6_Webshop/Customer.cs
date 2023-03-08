using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dag_6_Webshop
{
    internal class Customer
    {
        //Contact Info
        //Delivery address
        //List of orders
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public  Address HomeAdress { get; set; }
        public Customer() { }
        public Customer(int id,string name, string email, string phoneNumber,Address homeAdress)
        {
            CustomerID = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            HomeAdress = homeAdress;
        }
        public bool LoginToCustomerAccount()
        {
            Console.CursorVisible = true;
            Console.Write("\n*** Login Details ***");
            Console.Write("\n\nWhat is your Name: ");
            string name = Console.ReadLine();

            Console.Write("\n\nWhat is your Email: ");
            string email = Console.ReadLine();
            foreach (Customer cust in Data.CustomerList)
            {
                if (cust.Name == name&& cust.Email == email)
                {
                    Console.WriteLine($"Welcome {cust.Name},You have logged in");
                    return true;
                }
            }
            Console.WriteLine("Wrong Login Information");
            return false;

        }
        public void CreateCustomerAccount()
        {
            Console.CursorVisible = true;
            Console.WriteLine("\n*** Customer details ***");
            Console.Write("\n\nWhat is your name?: ");
            string name = Console.ReadLine();

            Console.Write("\nWhat is your Email: ");
            string email = Console.ReadLine();

            Console.Write("\nWhat is your Phone Number: ");
            string phoneNumber = Console.ReadLine();
            
            Console.WriteLine("\nADDRESS:");
            
            Console.Write("\nWhat is your street name: ");
            string streetName = Console.ReadLine();

            Console.Write("\nWhat is your Street Number: ");
            int streetNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nWhat is your city Name: ");
            string city = Console.ReadLine();

            Console.Write("\nWhat is your postalCode: ");
            int postalCode = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nWhat is your Country you live in?");
            string country = Console.ReadLine();

            Address address = new(streetName,streetNumber,city,postalCode,country);
            Customer customer = new(0, name, email, phoneNumber, address);
            Data.CustomerList.Add(customer);
            Console.Clear();
            Console.WriteLine($"\nHello {customer.Name}, your account has been created!");
            Console.WriteLine($"\nYour Email: {customer.Email}");
            Console.WriteLine($"\nYour Phone Number: {customer.PhoneNumber}");
            Console.WriteLine($"\nYour Address: {customer.HomeAdress}");
            //Genereate a customer ID by counting in the list.
            customer.CustomerID = Data.CustomerList.Count;
            Console.WriteLine($"\nYour Customer ID: {customer.CustomerID}");
            Console.ReadLine();
        }
        public override string ToString()
        {
            string addres = HomeAdress.ToString();
                      return $"{CustomerID}. {Name} {Email} {PhoneNumber}\n{addres}";
        }

    }
}
