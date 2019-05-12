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
        //один товар может принадлежать нескольким категориям
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
 

        public string Company { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Адрес картинки (формируется по ID)
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Отображается ли в ТОП
        /// </summary>
        public bool Favourite { get; set; }
    }
}
