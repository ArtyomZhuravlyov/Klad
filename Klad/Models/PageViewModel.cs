﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klad.Models
{
    public class PageViewModel 
    {
        public int count { get; private set; }
        public int pageSize { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            this.count = count;
            this.pageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasPreviousTwoPage
        {
            get
            {
                return (pageSize * 2 < count );
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public bool HasNextTwoPage
        {
            get
            {
                // return (PageNumber < TotalPages - 2 * pageSize);
                return (count >= pageSize * 2);
            }
        }
    }
}

