using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedLevelPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.InitialCatalog = @"c:\users\admin\documents\visual studio 2015\Projects\ConnectedLevelPart2\ConnectedLevelPart2\MyDB.mdf";
            builder.UserID = "admin";
            builder.Password = "123";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Вы вошли в базу данных");
                }
                catch(SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }


            Console.ReadLine();

        }
    }
}
