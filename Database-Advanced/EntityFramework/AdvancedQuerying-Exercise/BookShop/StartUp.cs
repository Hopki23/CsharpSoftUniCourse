namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            bool isParsed =
                Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            string[] books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, books);

        }

        //Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {

            string[] goldenBooks = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, goldenBooks);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksInfo = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var b in booksInfo)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] cmds = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            string[] books = context.Books
                .Where(b => b.BookCategories
                        .Any(bc => cmds.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return String.Join(Environment.NewLine, authors);
        }

        //Problem 09 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var copies = context.Authors
                .Select(c => new
                {
                    FullName = $"{c.FirstName} {c.LastName}",
                    Copies = c.Books.Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(c => c.Copies);

            foreach (var c in copies)
            {
                sb.AppendLine($"{c.FullName} - {c.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var totalProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                    .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name);

            foreach (var c in totalProfit)
            {
                sb.AppendLine($"{c.Name} ${c.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                                    .Take(3)
                                    .Select(b => new
                                    {
                                        b.Book.Title,
                                        ReleaseDate = b.Book.ReleaseDate!.Value.Year
                                    })
                                    .ToArray()
                })
                .ToArray()
                .OrderBy(c => c.Name);

            foreach (var c in mostRecentBooks)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 16
         public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();
            return booksToRemove.Count();
        }
    }
}


