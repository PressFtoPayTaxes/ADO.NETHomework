using System;
using System.Collections.Generic;

namespace DapperExtensions
{
    public class Article : Entity
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}