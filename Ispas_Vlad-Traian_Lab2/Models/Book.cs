using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispas_Vlad_Traian_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int? AuthorID { get; set; }
        public decimal Price { get; set; }

        public Author? Author { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
