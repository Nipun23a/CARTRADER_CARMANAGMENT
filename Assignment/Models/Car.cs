using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class Car
    {
       
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

    }
}
