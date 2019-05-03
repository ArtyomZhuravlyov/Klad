using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klad.Models
{
    public class PagesLink
    {
        /// <summary>
        /// Хранит список страниц для отображения
        /// </summary>
       public List<int> _pages { get; set; }

        /// <summary>
        /// Задаёт какие страницы отображать 1 2 3 или 1 2
        /// </summary>
        /// <param name="pageViewModel"></param>
        public PagesLink(PageViewModel pageViewModel)
        {
            _pages = new List<int>();

            if (pageViewModel.PageNumber == 1)
            {
                _pages.Add(pageViewModel.PageNumber);

                if (pageViewModel.HasNextPage)
                    _pages.Add(pageViewModel.PageNumber + 1);


                if (pageViewModel.HasNextTwoPage)
                    _pages.Add(pageViewModel.PageNumber + 2);

            }
            else if (pageViewModel.PageNumber == pageViewModel.TotalPages)
            {
                if (pageViewModel.HasPreviousTwoPage)
                    _pages.Add(pageViewModel.PageNumber - 2);

                if (pageViewModel.HasPreviousPage)
                    _pages.Add(pageViewModel.PageNumber - 1);

                _pages.Add(pageViewModel.PageNumber);
            }
            else
            {
                // создаем ссылку на предыдущую страницу, если она есть
                if (pageViewModel.HasPreviousPage)
                    _pages.Add(pageViewModel.PageNumber - 1);

                _pages.Add(pageViewModel.PageNumber);

                // создаем ссылку на следующую страницу, если она есть
                if (pageViewModel.HasNextPage)
                    _pages.Add(pageViewModel.PageNumber + 1);
            }
        }

    }
}
