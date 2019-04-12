using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDb = new DataSet("ShopDB");

            DataTable orders = new DataTable("Orders");
            DataTable customers = new DataTable("Customers");
            DataTable employees = new DataTable("Employees");
            DataTable orderDetails = new DataTable("Order_Details");
            DataTable products = new DataTable("Products");

            orders.Columns.Add("Id");
            orders.Columns.Add("Product");
            orders.PrimaryKey = new DataColumn[] { orders.Columns["Id"] };

            customers.Columns.Add("Id");
            customers.Columns.Add("Name");
            customers.PrimaryKey = new DataColumn[] { customers.Columns["Id"] };

            employees.Columns.Add("Id");
            employees.Columns.Add("Name");
            employees.PrimaryKey = new DataColumn[] { employees.Columns["Id"] };

            orderDetails.Columns.Add("Id");
            orderDetails.Columns.Add("Order");
            orderDetails.Columns.Add("Customer");
            orderDetails.Columns.Add("Employee");
            orderDetails.PrimaryKey = new DataColumn[] { orderDetails.Columns["Id"] };

            products.Columns.Add("Id");
            products.Columns.Add("Name");
            products.PrimaryKey = new DataColumn[] { products.Columns["Id"] };

            shopDb.Tables.Add(orders);
            shopDb.Tables.Add(customers);
            shopDb.Tables.Add(employees);
            shopDb.Tables.Add(orderDetails);
            shopDb.Tables.Add(products);

            shopDb.Relations.Add("FK_Products_Orders", products.Columns["Id"], orders.Columns["Product"]);
            shopDb.Relations.Add("FK_Orders_OrderDetails", orders.Columns["Id"], orderDetails.Columns["Order"]);
            shopDb.Relations.Add("FK_Customers_OrderDetails", customers.Columns["Id"], orderDetails.Columns["Customer"]);
            shopDb.Relations.Add("FK_Employees_OrderDetails", employees.Columns["Id"], orderDetails.Columns["Employee"]);
        }
    }
}
