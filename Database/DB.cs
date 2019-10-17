using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class DB
    {
        private static masterEntities myDb = new masterEntities();
        public static IEnumerable<Product> GetProducts()
        {
            return myDb.Products.ToList();
        }

        public static Product GetProduct(int id)
        {
            return myDb.Products.Find(id);
        }

        public static void AddProduct(Product p)
        {
            try
            {
                myDb.Products.Add(p);
                myDb.SaveChanges();

                Console.WriteLine("Record Created in Products");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Add Record to Products");
            }
        }

        public static void DeleteCustomer(int id)
        {
            try
            {
                Customer c = myDb.Customers.Find(id);
                myDb.Customers.Remove(c);
                myDb.SaveChanges();

                Console.WriteLine("Record Deleted.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot delete, record has foreign references");
            }
        }

        public static void AddCustomer(Customer c)
        {
            try
            {
                myDb.Customers.Add(c);
                myDb.SaveChanges();

                Console.WriteLine("Record Created in Customer");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Add Record in Customer");
            }
            
        }

        public static void AddSale(Sale s)
        {
            try
            {
                myDb.Sales.Add(s);
                myDb.SaveChanges();

                Console.WriteLine("Record Created in Sales");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Add Record in Sales");
            }
        }

        public static void UpdateCustomer(Customer c)
        {   
            if (c.CustomerFirstName != null)
            {
                myDb.Customers.Find(c.CustomerId).CustomerFirstName = c.CustomerFirstName;
            }

            if (c.CustomerLastName != null)
            {
                myDb.Customers.Find(c.CustomerId).CustomerLastName = c.CustomerLastName;
            }
            
            myDb.SaveChanges();
        }

        public static List<Sale> GetSales()
        { 
            return myDb.Sales.ToList();
        }
    }
}
