using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klad.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        //public PageViewModel PageViewModel { get; set; }

        public List<string> ListCategory { get; set; }

        public string CurrentCategory { get; set; }

        public PagesLink Pages { get; set; }

        public Dictionary<string, Dictionary<string, string>> DiscriptionCatalog { get;  set; }
    }
}
