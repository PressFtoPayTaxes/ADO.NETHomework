using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public class ArticlesRepository : IRepository<Article>
    {
        private string _connectionString;
        private DbConnection _connection;

        public ArticlesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void Add(Article item)
        {
            _connection.Execute("insert into Articles values(@Id, @AuthorName, @Date, @Text, @Theme)", item);
        }

        public void Delete(Guid id)
        {
            _connection.Execute("delete from Articles where Id = @id", id);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public List<Article> Select()
        {
            return _connection.Query<Article>("select * from Articles").AsList();
        }

        public void Update(Article item)
        {
            var sqlQuery = "update Articles set AuthorName = @AuthorName and Date = @Date and Theme = @Theme and Text = @Text where Id = @Id";
            _connection.Execute(sqlQuery, item);
        }
    }
}
