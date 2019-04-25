using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DbUp;
using System.Reflection;
using System.Configuration;

namespace DapperExtensions
{
    class Program
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

        static void Main(string[] args)
        {
            CheckConnection();

            while (true)
            {
                Console.WriteLine("1 - Написать статью\n2 - Просмотреть статьи\n3 - Выход");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1: WriteArticle(); break;
                    case 2: ShowArticles(); break;
                    case 3: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        break;
                }
            }
        }

        private static void WriteArticle()
        {
            var article = new Article();

            while (article.AuthorName == null || article.AuthorName == string.Empty)
            {
                Console.Write("Введите ваше имя: ");
                article.AuthorName = Console.ReadLine();
            }

            while (article.Theme == null || article.Theme == string.Empty)
            {
                Console.Write("Введите заголовок: ");
                article.Theme = Console.ReadLine();
            }

            while (article.Text == null || article.Text == string.Empty)
            {
                Console.WriteLine("Вводите текст новости: ");
                article.Text = Console.ReadLine();
            }

            article.Date = DateTime.Now;

            using (var repository = new ArticlesRepository())
            {
                repository.Add(article);
            }
        }

        private static void ShowArticles()
        {
            List<Article> articles = new List<Article>();
            using (var repository = new ArticlesRepository())
            {
                articles = repository.Select();
            }
            for (int i = 0; i < articles.Count; i++)
                Console.WriteLine($"{i + 1}: {articles[i].Theme}");

            var selectedArticle = new Article();

            while (true)
            {
                Console.Write("Выберите номер статьи: ");
                int answer = int.Parse(Console.ReadLine());

                if (answer <= 0 || answer > articles.Count)
                {
                    Console.WriteLine("Такого номера нет");
                    continue;
                }

                selectedArticle = articles[answer - 1];
                break;
            }

            Console.WriteLine($"{selectedArticle.AuthorName} {selectedArticle.Date}\n{selectedArticle.Text}");

            var comments = new List<Comment>();
            using (var repository = new CommentsRepository())
            {
                comments = (from comment
                            in repository.Select()
                            where comment.ArticleId == selectedArticle.Id
                            select comment).AsList();
            }

            Console.WriteLine("Комментарии:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"({comment.Date}) {comment.AuthorName}: {comment.Text}");
            }

            WriteComment(selectedArticle.Id);
        }

        private static void WriteComment(Guid articleId)
        {
            while (true)
            {
                Console.WriteLine("Желаете оставить комментарий? (1 - да, 2 - нет)");
                int answer = int.Parse(Console.ReadLine());

                var comment = new Comment();
                switch (answer)
                {
                    case 1:
                        while (comment.AuthorName == null || comment.AuthorName == string.Empty)
                        {
                            Console.Write("Введите свое имя: ");
                            comment.AuthorName = Console.ReadLine();
                        }
                        while (comment.Text == null || comment.Text == string.Empty)
                        {
                            Console.Write("Введите ваш комментарий: ");
                            comment.Text = Console.ReadLine();
                        }
                        comment.Date = DateTime.Now;
                        comment.ArticleId = articleId;

                        using (var repository = new CommentsRepository())
                        {
                            repository.Add(comment);
                        }

                        break;
                    case 2: break;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        continue;
                }
                break;
            }
        }

        private static void CheckConnection()
        {
            EnsureDatabase.For.SqlDatabase(_connectionString);

            var upgrader = DeployChanges.To
            .SqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful) throw new Exception("Ошибка соединения");
        }
    }
}
