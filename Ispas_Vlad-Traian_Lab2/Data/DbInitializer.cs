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
                    new Author { FirstName = "Mircea", LastName = "Eliade" }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();

                context.Books.AddRange(
                    new Book { Title = "Baltagul", AuthorID = authors[0].AuthorID, Price = Decimal.Parse("22") },
                    new Book { Title = "Enigma Otiliei", AuthorID = authors[1].AuthorID, Price = Decimal.Parse("18") },
                    new Book { Title = "Maytrei", AuthorID = authors[2].AuthorID, Price = Decimal.Parse("27") }
                    );

                context.Customers.AddRange(
                    new Customer { Name = "Popescu Marcela", Address = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Address = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                    );

                context.SaveChanges();
            }
        }
    }
}
