using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelPart2
{
    public class UsersHandler
    {
        private readonly string _connectionString;
        private readonly string _provider;

        public UsersHandler()
        {
            _provider = ConfigurationManager.ConnectionStrings["appString"].ProviderName;
            _connectionString = ConfigurationManager.ConnectionStrings["appString"].ConnectionString;
        }

        public DataSet GetUsers()
        {
            var factory = DbProviderFactories.GetFactory(_provider);
            var usersSet = new DataSet();

            using (var connection = factory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;
                command.CommandText = "select * from Users";

                var dataAdapter = factory.CreateDataAdapter();
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(usersSet, "Users");
            }

            return usersSet;
        }

        public void AddUser(string login, string password, string address, string phoneNumber, bool isAdmin)
        {
            var user = GetUsers();
            var factory = DbProviderFactories.GetFactory(_provider);

            var dataAdapter = factory.CreateDataAdapter();
            using (var connection = factory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;
                command.CommandText = "select * from Users";

                dataAdapter.SelectCommand = command;
                var commandBuilder = factory.CreateCommandBuilder();
                commandBuilder.DataAdapter = dataAdapter;

                var random = new Random();
                user.Tables["Users"].Rows.Add(random.Next(1, 99999), login, password, address, phoneNumber, isAdmin);

                dataAdapter.Update(user, "Users");
            }
        }

        public void RedactUser(string login, string newPassword, string newAddress, string newPhoneNumber, bool newIsAdmin)
        {
            var factory = DbProviderFactories.GetFactory(_provider);

            using (var connection = factory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;
                command.CommandText = "select * from Users";

                var dataAdapter = factory.CreateDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.SelectCommand.Connection = connection;

                var builder = factory.CreateCommandBuilder();
                builder.DataAdapter = dataAdapter;

                var users = GetUsers();
                object neededRow = new object();
                foreach (DataRow row in users.Tables["Users"].Rows)
                {
                    if (row.ItemArray[1].ToString() == login)
                    {
                        neededRow = row;
                        break;
                    }
                }
                var dataRow = neededRow as DataRow;
                dataRow.BeginEdit();
                dataRow.ItemArray = new object[] { dataRow.ItemArray[0], dataRow.ItemArray[1], newPassword, newAddress, newPhoneNumber, newIsAdmin };
                dataRow.EndEdit();
                dataAdapter.Update(users, "Users");
            }
        }

        public void DeleteUser(string login)
        {
            var factory = DbProviderFactories.GetFactory(_provider);

            using (var connection = factory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;

                command.CommandText = "select * from Users";

                var dataAdapter = factory.CreateDataAdapter();
                dataAdapter.SelectCommand = command;

                var builder = factory.CreateCommandBuilder();
                builder.DataAdapter = dataAdapter;

                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Users");

                foreach(DataRow row in dataSet.Tables["Users"].Rows)
                {
                    if (row.ItemArray[1].ToString() == login)
                        row.Delete();
                }

                dataAdapter.Update(dataSet, "Users");
            }
        }
    }
}
