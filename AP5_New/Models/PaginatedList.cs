using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalRecord { get; set; }

        public PaginatedList(List<T> items,int count,int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            PageSize = pageSize;
            TotalRecord = count;
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get 
            { 
                return (PageIndex > 1); 
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> Create(List<T> source,int pageIndex,int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items,count,pageIndex,pageSize);
        }
    }
}
