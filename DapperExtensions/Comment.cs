using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public class Comment : Entity
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
