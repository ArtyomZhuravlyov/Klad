using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klad.Models
{
    public class PageViewModel 
    {
        /// <summary>
        /// Общее количество товаров
        /// </summary>
        public int count { get; private set; }
        /// <summary>
        /// Количество товаров на одной странице
        /// </summary>
        public int pageSize { get; private set; }
        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// Количество всех страниц по данной категории
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Хранит список страниц для отображения
        /// </summary>
        public List<int> _pages { get; private set; }
        /// <summary>
        /// указывать ли последнюю стрелку
        /// </summary>       
        public bool LastArrow { get; private set; }
        /// <summary>
        /// указывать ли первую стрелку
        /// </summary>
        public bool FirstArrow { get; private set; }
        /// <summary>
        /// По сколько в право и влево страниц видно
        /// </summary>
        private const int CountDigit = 4;

        public int FirstPage { get; private set; }
        public int LastPage { get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            this.count = count;
            this.pageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            //какое число в конце
            if(CurrentPage + CountDigit < TotalPages) //если лежит в диапазоне нормально
            {
                LastArrow = true;
                LastPage = CurrentPage + CountDigit;
            }
            else //если упёрлось в конец
            {
                LastArrow = false;
                //FirstArrow = true;
                LastPage = TotalPages;
                //FirstPage = LastPage
            }

            //какое число в начале
            if (CurrentPage - CountDigit > 1) //если лежит в диапазоне нормально
            {
                FirstPage = CurrentPage - CountDigit;
                FirstArrow = true;
            }
            else //если упёрлось в начало
            {
                FirstPage = 1;
                FirstArrow = false;
            }
        }



        //public bool HasPreviousPage //старый вариант //отображение максимум 3 страницы
        //{
        //    get
        //    {
        //        return (PageNumber > 1);
        //    }
        //}

        //public bool HasPreviousTwoPage
        //{
        //    get
        //    {
        //        return (pageSize * 2 < count );
        //    }
        //}

        //public bool HasNextPage
        //{
        //    get
        //    {
        //        return (PageNumber < TotalPages);
        //    }
        //}

        //public bool HasNextTwoPage
        //{
        //    get
        //    {
        //        // return (PageNumber < TotalPages - 2 * pageSize);
        //        return (count >= pageSize * 2);
        //    }
        //}
    }
}

