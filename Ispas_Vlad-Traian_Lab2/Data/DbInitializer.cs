using Microsoft.EntityFrameworkCore;
using Ispas_Vlad_Traian_Lab2.Models;

namespace Ispas_Vlad_Traian_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                var authors = new Author[]
                {
                    new Author { FirstName = "Mihail", LastName = "Sadoveanu" },
                    new Author { FirstName = "George", LastName = "Calinescu" },
                    new Author { FirstName = "Mircea", LastName = "Eliade" },
                    new Author { FirstName = "Guillaume", LastName = "Musso" },
                    new Author { FirstName = "Cella", LastName = "Serghi" },
                    new Author { FirstName = "Jerome David", LastName = "Salinger" }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();

                context.Books.AddRange(
                    new Book { Title = "Baltagul", AuthorID = authors[0].AuthorID, Price = Decimal.Parse("20") },
                    new Book { Title = "Enigma Otiliei", AuthorID = authors[1].AuthorID, Price = Decimal.Parse("10") },
                    new Book { Title = "Maytrei", AuthorID = authors[2].AuthorID, Price = Decimal.Parse("22") },
                    new Book { Title = "Fata de hartie", AuthorID = authors[3].AuthorID, Price = Decimal.Parse("25") },
                    new Book { Title = "Panza de paianjen", AuthorID = authors[4].AuthorID, Price = Decimal.Parse("19") },
                    new Book { Title = "De veghe in lanul de secara", AuthorID = authors[5].AuthorID, Price = Decimal.Parse("15") }
                    );

                context.Customers.AddRange(
                    new Customer { Name = "Popescu Marcela", Address = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Address = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                    );

                context.SaveChanges();

                var orders = new Order[]
                {
                    new Order{ BookID = 1, CustomerID = 1, OrderDate = DateTime.Parse("2021-02-25") },
                    new Order{ BookID = 2, CustomerID = 2, OrderDate = DateTime.Parse("2021-09-28") },
                    new Order{ BookID = 3, CustomerID = 2, OrderDate = DateTime.Parse("2021-10-28") },
                    new Order{ BookID = 4, CustomerID = 1, OrderDate = DateTime.Parse("2021-09-28") },
                    new Order{ BookID = 5, CustomerID = 1, OrderDate = DateTime.Parse("2021-09-28") },
                    new Order{ BookID = 6, CustomerID = 1, OrderDate = DateTime.Parse("2021-10-28") }
                };

                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }

                context.SaveChanges();

                var publishers = new Publisher[]
                {
                    new Publisher{ PublisherName = "Humanitas", Address = "Str. Aviatorilor, nr. 40, Bucuresti" },
                    new Publisher{ PublisherName = "Nemira", Address = "Str. Plopilor, nr. 35, Ploiesti"},
                    new Publisher{ PublisherName = "Paralela 45", Address = "Str. Cascadelor, nr. 22, Cluj-Napoca" }
                };

                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }

                context.SaveChanges();

                var books = context.Books;
                var publishedbooks = new PublishedBook[]
                {
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Maytrei" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                    },
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                    },
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Baltagul" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
                    },
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                    },
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                    },
                    new PublishedBook {
                    BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                    },
                };

                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }

                context.SaveChanges();
            }
        }
    }
}
