using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedLevelPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "create table [dbo].[Group] ( [Id] int identity(1, 1) not null primary key, [Name] nvarchar(50) not null check([Name] != \'\') )";
                command.ExecuteNonQuery();
            }

        }
    }
}
