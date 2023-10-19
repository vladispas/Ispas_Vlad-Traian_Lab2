using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ispas_Vlad_Traian_Lab2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
