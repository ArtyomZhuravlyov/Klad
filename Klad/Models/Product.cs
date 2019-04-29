using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klad.Models
{
    public class Product
    {
        public int Id { get; set; }
      //  public int IDProduct { get; set; }
  
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}
