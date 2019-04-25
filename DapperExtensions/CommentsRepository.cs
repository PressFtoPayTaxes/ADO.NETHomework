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
    public class CommentsRepository : IRepository<Comment>
    {
        private string _connectionString;
        private DbConnection _connection;

        public CommentsRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void Add(Comment item)
        {
            _connection.Execute("insert into Comments values(@Id, @AuthorName, @Date, @Text, @ArticleId)", item);
        }

        public void Delete(Guid id)
        {
            _connection.Execute("delete from Comments where Id = @id", id);
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public List<Comment> Select()
        {
            return _connection.Query<Comment>("select * from Comments").AsList();
        }

        public void Update(Comment item)
        {
            var sqlQuery = "update Comments set AuthorName = @AuthorName and Date = @Date and Text = @Text and ArticleId = @ArticleId where Id = @Id";
            _connection.Execute(sqlQuery, item);
        }
    }
}
