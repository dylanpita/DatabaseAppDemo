using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace DatabaseAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProducts = DB.GetProducts();

            foreach (var product in myProducts)
            {
                Debug.WriteLine("ID: " + product.ProductId + "/nDesc: " + product.ProductDescription);
            }

            /* Adding Product */
            Product p = new Product();
            p.ProductDescription = "Vibrator";
            p.ProductUpc = "123";

            DB.AddProduct(p);

            /* Adding Customer */
            Customer c = new Customer();
            c.CustomerFirstName = "Remi";
            c.CustomerLastName = "Johnathan";

            DB.AddCustomer(c);
            
            /* Adding Sale */
            Sale s = new Sale();
            s.SaleDate = DateTime.Now;
            s.ProductId = 4;
            s.CustomerId = 4;

            DB.AddSale(s);
            
            /* Deleting Customer */
            DB.DeleteCustomer(4);

            /* Display Sales with Customer and Product */
            var mySales = DB.GetSales();
            foreach (var sale in mySales)
            {
                Console.WriteLine(sale.SaleId + " | " +sale.SaleDate+ " | " +sale.Customer.CustomerFirstName+ " " +sale.Customer.CustomerLastName+ " | " +sale.Product.ProductDescription);
            }

            /* Update Customer */
            Customer c1 = new Customer();
            c1.CustomerId = 3;
            c1.CustomerFirstName = "Brendan";

            DB.UpdateCustomer(c1);

            
        }
    }
}
